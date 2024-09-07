import { TestBed } from '@angular/core/testing';

import { SingerApiService } from './singer-api.service';

describe('SingerApiService', () => {
  let service: SingerApiService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(SingerApiService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
