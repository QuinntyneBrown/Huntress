import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AggregatePrivilegesComponent } from './aggregate-privileges.component';

describe('AggregatePrivilegesComponent', () => {
  let component: AggregatePrivilegesComponent;
  let fixture: ComponentFixture<AggregatePrivilegesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AggregatePrivilegesComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AggregatePrivilegesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
