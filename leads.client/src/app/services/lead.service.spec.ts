import { TestBed } from '@angular/core/testing';

import { LeadService } from './lead.service';
import { HttpClientModule } from '@angular/common/http';
import { AppModule } from '../app.module';

describe('LeadService', () => {
  let service: LeadService;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientModule, AppModule],
    });
    service = TestBed.inject(LeadService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
