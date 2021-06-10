import { TestBed } from '@angular/core/testing';

import { InstagramFeedService } from './instagram-feed.service';

describe('InstagramFeedService', () => {
  let service: InstagramFeedService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(InstagramFeedService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
