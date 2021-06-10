import { Injectable, Inject } from '@angular/core';
import { baseUrl } from '@core/constants';
import { HttpClient } from '@angular/common/http';
import { ImageContent } from '@api';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { IPagableService } from '@core/ipagable-service';
import { EntityPage } from '@core/entity-page';

@Injectable({
  providedIn: 'root'
})
export class ImageContentService implements IPagableService<ImageContent> {

  uniqueIdentifierName: string = "imageContentId";

  constructor(
    @Inject(baseUrl) private readonly _baseUrl: string,
    private readonly _client: HttpClient
  ) { }

  getPage(options: { pageIndex: number; pageSize: number; }): Observable<EntityPage<ImageContent>> {
    return this._client.get<EntityPage<ImageContent>>(`${this._baseUrl}api/imageContent/page/${options.pageSize}/${options.pageIndex}`)
  }

  public get(): Observable<ImageContent[]> {
    return this._client.get<{ imageContents: ImageContent[] }>(`${this._baseUrl}api/imageContent`)
      .pipe(
        map(x => x.imageContents)
      );
  }

  public getById(options: { imageContentId: string }): Observable<ImageContent> {
    return this._client.get<{ imageContent: ImageContent }>(`${this._baseUrl}api/imageContent/${options.imageContentId}`)
      .pipe(
        map(x => x.imageContent)
      );
  }

  public remove(options: { imageContent: ImageContent }): Observable<void> {
    return this._client.delete<void>(`${this._baseUrl}api/imageContent/${options.imageContent.imageContentId}`);
  }

  public create(options: { imageContent: ImageContent }): Observable<{ imageContent: ImageContent }> {
    return this._client.post<{ imageContent: ImageContent }>(`${this._baseUrl}api/imageContent`, { imageContent: options.imageContent });
  }
  
  public update(options: { imageContent: ImageContent }): Observable<{ imageContent: ImageContent }> {
    return this._client.put<{ imageContent: ImageContent }>(`${this._baseUrl}api/imageContent`, { imageContent: options.imageContent });
  }
}
