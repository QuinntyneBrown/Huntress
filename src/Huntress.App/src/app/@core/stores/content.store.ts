import { HttpClient } from "@angular/common/http";
import { Inject, Injectable } from "@angular/core";
import { queryStore } from "@quinntyne/query-store";
import { Observable, of } from "rxjs";
import { BASE_URL } from "@core";
import { Content, ContentService } from "@api";
import { v4 as uuidv4 } from 'uuid';

const CONTENTS = "CONTENTS";

@Injectable({
  providedIn: "root"
})
export class ContentStore extends queryStore(ContentService) {
  constructor(
    @Inject(BASE_URL) _baseUrl:string,
    _client: HttpClient
  ) {
    super(_baseUrl, _client);
  }

  public get$(): Observable<Content[]> {
    return super.from$(() => super.get(), [CONTENTS]);
  }

  public getByName$(options:{ name: string }): Observable<Content> {
    return super.from$(() => super.getByName(options), [CONTENTS, `CONTENT_${options.name}`]);
  }

  public create$(content: Content) {
    return super.withRefresh(super.create({ content }), [CONTENTS])
  }

  public update$(content:Content) {
    return super.withRefresh(super.update({ content }),[CONTENTS])
  }

  public remove$(content:Content) {
    return super.withRefresh(super.remove({ content }),[CONTENTS])
  }
}
