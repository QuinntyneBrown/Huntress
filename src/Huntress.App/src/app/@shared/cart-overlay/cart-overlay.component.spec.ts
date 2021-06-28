import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CartOverlayComponent } from './cart-overlay.component';

describe('CartOverlayComponent', () => {
  let component: CartOverlayComponent;
  let fixture: ComponentFixture<CartOverlayComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CartOverlayComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CartOverlayComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
