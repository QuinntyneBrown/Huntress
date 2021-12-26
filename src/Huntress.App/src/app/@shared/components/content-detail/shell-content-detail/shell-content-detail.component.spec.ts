import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShellContentDetailComponent } from './shell-content-detail.component';

describe('ShellContentDetailComponent', () => {
  let component: ShellContentDetailComponent;
  let fixture: ComponentFixture<ShellContentDetailComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ShellContentDetailComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ShellContentDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
