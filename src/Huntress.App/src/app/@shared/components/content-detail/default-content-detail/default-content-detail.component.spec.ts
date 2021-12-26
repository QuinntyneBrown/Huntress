import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DefaultContentDetailComponent } from './default-content-detail.component';

describe('DefaultContentDetailComponent', () => {
  let component: DefaultContentDetailComponent;
  let fixture: ComponentFixture<DefaultContentDetailComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DefaultContentDetailComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DefaultContentDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
