import { HttpClient } from "@angular/common/http";
import { Inject, Injectable } from "@angular/core";
import { Role, RoleService } from "@api";
import { baseUrl } from "@core";
import { queryStore } from "@quinntyne/query-store";
import { Observable } from "rxjs";
import { v4 as uuidv4 } from 'uuid';

const ROLES = uuidv4();

@Injectable({
  providedIn: "root"
})
export class RoleStore extends queryStore(RoleService) {
  constructor(
    @Inject(baseUrl) _baseUrl:string,
    _client: HttpClient
  ) {
    super(_baseUrl, _client);
  }

  public get$(): Observable<Role[]> {
    return super.from$(() => super.get(), [ROLES]);
  }

  public create$(role: Role) {
    return super.withRefresh(super.create({ role }), [ROLES])
  }

  public update$(role:Role) {
    return super.withRefresh(super.update({ role }),[ROLES])
  }
}
