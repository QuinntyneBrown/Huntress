import { TestBed } from '@angular/core/testing';

import { ImageContentService } from './image-content.service';

describe('ImageContentService', () => {
  let service: ImageContentService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ImageContentService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
