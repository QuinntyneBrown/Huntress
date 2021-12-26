import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CssVariableListComponent } from './css-variable-list.component';

describe('CssVariableListComponent', () => {
  let component: CssVariableListComponent;
  let fixture: ComponentFixture<CssVariableListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CssVariableListComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CssVariableListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
