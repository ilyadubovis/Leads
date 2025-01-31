import { TestBed } from '@angular/core/testing';

import { LeadSignalRService } from './leadSignalR.service';
import { AppModule } from '../app.module';

describe('LeadSignalRService', () => {
  let service: LeadSignalRService;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [AppModule],
    });
    service = TestBed.inject(LeadSignalRService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
