import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CssVariableDetailComponent } from './css-variable-detail.component';

describe('CssVariableDetailComponent', () => {
  let component: CssVariableDetailComponent;
  let fixture: ComponentFixture<CssVariableDetailComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CssVariableDetailComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CssVariableDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
