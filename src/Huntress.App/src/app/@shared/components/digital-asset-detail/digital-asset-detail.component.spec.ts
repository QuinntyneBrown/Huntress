import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DigitalAssetDetailComponent } from './digital-asset-detail.component';

describe('DigitalAssetDetailComponent', () => {
  let component: DigitalAssetDetailComponent;
  let fixture: ComponentFixture<DigitalAssetDetailComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DigitalAssetDetailComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DigitalAssetDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
