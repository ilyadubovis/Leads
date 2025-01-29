import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LeadListComponent } from './lead-list.component';
import { HttpClientModule } from '@angular/common/http';
import { AppModule } from '../../app.module';

describe('LeadListComponent', () => {
  let component: LeadListComponent;
  let fixture: ComponentFixture<LeadListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [LeadListComponent],
      imports: [HttpClientModule, AppModule],
    })
    .compileComponents();

    fixture = TestBed.createComponent(LeadListComponent);

    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
