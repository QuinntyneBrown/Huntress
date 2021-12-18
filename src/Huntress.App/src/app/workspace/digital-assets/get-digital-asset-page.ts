import { Injectable } from "@angular/core";
import { DigitalAssetService } from "@api";

@Injectable({
  providedIn: "root"
})
export class GetDigitalAssetPage {
  constructor(
    private readonly _cache: Cache,
    private readonly _digitalAssetService: DigitalAssetService
  ) { }

  public query(options: { pageIndex: number, pageSize: number}) {
    return this._digitalAssetService.getPage(options);
  }
}
