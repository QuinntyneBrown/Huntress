import { ComponentFixture, TestBed } from '@angular/core/testing';

import { QuanityComponent } from './quanity.component';

describe('QuanityComponent', () => {
  let component: QuanityComponent;
  let fixture: ComponentFixture<QuanityComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ QuanityComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(QuanityComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
