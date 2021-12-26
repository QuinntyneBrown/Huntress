import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LandingContentDetailComponent } from './landing-content-detail.component';

describe('LandingContentDetailComponent', () => {
  let component: LandingContentDetailComponent;
  let fixture: ComponentFixture<LandingContentDetailComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ LandingContentDetailComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(LandingContentDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
