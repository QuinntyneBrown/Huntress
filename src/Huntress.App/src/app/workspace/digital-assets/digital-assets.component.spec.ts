import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DigitalAssetsComponent } from './digital-assets.component';

describe('DigitalAssetsComponent', () => {
  let component: DigitalAssetsComponent;
  let fixture: ComponentFixture<DigitalAssetsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DigitalAssetsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DigitalAssetsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
