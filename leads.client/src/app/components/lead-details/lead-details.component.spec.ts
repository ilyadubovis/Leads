import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LeadDetailsComponent } from './lead-details.component';
import { HttpClientModule } from '@angular/common/http';
import { AppModule } from '../../app.module';

describe('LeadDetailsComponent', () => {
  let component: LeadDetailsComponent;
  let fixture: ComponentFixture<LeadDetailsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [LeadDetailsComponent],
      imports: [HttpClientModule, AppModule],
    })
    .compileComponents();

    fixture = TestBed.createComponent(LeadDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
