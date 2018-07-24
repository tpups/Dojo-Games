import { TestBed, inject } from '@angular/core/testing';

import { DojoService } from './dojo.service';

describe('AuthorService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [DojoService]
    });
  });

  it('should be created', inject([DojoService], (service: DojoService) => {
    expect(service).toBeTruthy();
  }));
});