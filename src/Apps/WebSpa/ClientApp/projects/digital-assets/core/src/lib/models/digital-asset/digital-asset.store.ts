// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import { inject, Injectable } from "@angular/core";
import { ComponentStore, tapResponse } from "@ngrx/component-store";
import { exhaustMap, map, noop, tap, withLatestFrom } from "rxjs";
import { DigitalAsset } from "./digital-asset";
import { DigitalAssetService } from "./digital-asset.service";

export interface DigitalAssetState {
    digitalAssets: DigitalAsset[]
}

const initialDigitalAssetState = {
    digitalAssets: []
};

@Injectable({
    providedIn:"root"
})
export class DigitalAssetStore extends ComponentStore<DigitalAssetState> {
    private  readonly _digitalAssetService = inject(DigitalAssetService);

    constructor() {
        super(initialDigitalAssetState);        
    }

    readonly save = (digitalAsset:DigitalAsset, nextFn: {(response:any): void} | null = null, errorFn: {(response:any): void} | null = null) => {        
        
        const apiRequest$ = digitalAsset.digitalAssetId ? this._digitalAssetService.update({ digitalAsset }) : this._digitalAssetService.create({ digitalAsset });
        
        const updateFn = digitalAsset?.digitalAssetId ? ([response, digitalAssets]: [any, DigitalAsset[]]) => this.patchState({

            digitalAssets: digitalAssets.map(t => response.digitalAsset.digitalAssetId == t.digitalAssetId ? response.digitalAsset : t)
        })
        :(([response, digitalAssets]: [any, DigitalAsset[]]) => this.patchState({ digitalAssets: [...digitalAssets, response.digitalAsset ]}));
        
        return this.effect<void>(
            exhaustMap(()=> apiRequest$.pipe(
                withLatestFrom(this.select(x => x.digitalAssets)),
                tap(updateFn),
                tapResponse(
                    nextFn || noop,
                    errorFn || noop
                )
            )
        ))();
    }

    readonly delete = this.effect<DigitalAsset>(
        exhaustMap((digitalAsset) => this._digitalAssetService.delete({ digitalAsset: digitalAsset }).pipe( 
            withLatestFrom(this.select(x => x.digitalAssets )),           
            tapResponse(
                ([_, digitalAssets]) => this.patchState({ digitalAssets: digitalAssets.filter(t => t.digitalAssetId != digitalAsset.digitalAssetId )}),
                noop
            )
        ))
    );

    readonly load = this.effect<void>(
        exhaustMap(_ => this._digitalAssetService.get().pipe(            
            tapResponse(
                digitalAssets => this.patchState({ digitalAssets }),
                noop                
            )
        ))
    );    
}
