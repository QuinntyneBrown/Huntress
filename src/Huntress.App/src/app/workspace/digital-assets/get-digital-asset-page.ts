import { Injectable } from "@angular/core";
import { DigitalAssetService } from "@api";
import { Cache } from "@core/stateful-services/abstractions/cache";
import { DIGITAL_ASSETS } from "./actions";

@Injectable({
  providedIn: "root"
})
export class GetDigitalAssetPage {
  constructor(
    private readonly _cache: Cache,
    private readonly _digitalAssetService: DigitalAssetService
  ) { }

  public query(options: { pageIndex: number, pageSize: number}) {
    const func = () => this._digitalAssetService.getPage(options);
    return this._cache.fromCacheOrServiceWithRefresh$(`${DIGITAL_ASSETS}_${options.pageIndex}_${options.pageSize}`,func, DIGITAL_ASSETS);
  }
}
