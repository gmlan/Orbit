import { TestBed, inject } from '@angular/core/testing';

import { JsonQueryService } from './json-query.service';

describe('JsonQueryService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [JsonQueryService]
    });
  });

  it('should be created', inject([JsonQueryService], (service: JsonQueryService) => {
    expect(service).toBeTruthy();
  }));
});
