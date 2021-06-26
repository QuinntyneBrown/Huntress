import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CssVariablesComponent } from './css-variables.component';

describe('CssVariablesComponent', () => {
  let component: CssVariablesComponent;
  let fixture: ComponentFixture<CssVariablesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CssVariablesComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CssVariablesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
