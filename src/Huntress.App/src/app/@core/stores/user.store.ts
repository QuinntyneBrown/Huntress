import { HttpClient } from "@angular/common/http";
import { Inject, Injectable } from "@angular/core";
import { queryStore } from "@quinntyne/query-store";
import { Observable, of } from "rxjs";
import { baseUrl } from "@core";
import { User, UserService } from "@api";
import { v4 as uuidv4 } from 'uuid';

const USERS = "USERS";
const SELECTED_USER = "USER";

@Injectable({
  providedIn: "root"
})
export class UserStore extends queryStore(UserService) {
  constructor(
    @Inject(baseUrl) _baseUrl:string,
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

  public setSelected(user:User) {
    super.setState<User>(SELECTED_USER,of(user));
  }

  public clearSelected() {
    super.setState<User>(SELECTED_USER,of({ } as User));
  }

  public selected$ = this.select<User>(SELECTED_USER)
}
