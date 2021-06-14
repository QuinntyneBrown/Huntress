import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ReturnPolicySectionComponent } from './return-policy-section.component';

describe('ReturnPolicySectionComponent', () => {
  let component: ReturnPolicySectionComponent;
  let fixture: ComponentFixture<ReturnPolicySectionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ReturnPolicySectionComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ReturnPolicySectionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
