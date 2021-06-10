import { TestBed } from '@angular/core/testing';

import { InstagramFeedItemService } from './instagram-feed-item.service';

describe('InstagramFeedItemService', () => {
  let service: InstagramFeedItemService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(InstagramFeedItemService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
