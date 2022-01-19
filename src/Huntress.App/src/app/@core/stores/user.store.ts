import { HttpClient } from "@angular/common/http";
import { Inject, Injectable } from "@angular/core";
import { queryStore } from "@quinntyne/query-store";
import { Observable } from "rxjs";
import { BASE_URL } from "@core";
import { User, UserService } from "@api";


const USERS = "USERS";

@Injectable({
  providedIn: "root"
})
export class UserStore extends queryStore(UserService) {
  constructor(
    @Inject(BASE_URL) _baseUrl:string,
    _client: HttpClient
  ) {
    super(_baseUrl, _client);
  }

  public get$(): Observable<User[]> {
    return super.from$(() => super.get(), [USERS]);
  }

  public create$(user: User) {
    return super.withRefresh(super.create({ user }), [USERS])
  }

  public update$(user:User) {
    return super.withRefresh(super.update({ user }),[USERS])
  }

  public remove$(user:User) {
    return super.withRefresh(super.remove({ user }),[USERS])
  }
}
