import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BentoBoxComponent } from './bento-box.component';

describe('BentoBoxComponent', () => {
  let component: BentoBoxComponent;
  let fixture: ComponentFixture<BentoBoxComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BentoBoxComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(BentoBoxComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
