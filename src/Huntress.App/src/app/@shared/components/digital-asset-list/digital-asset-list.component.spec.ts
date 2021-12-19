import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DigitalAssetListComponent } from './digital-asset-list.component';

describe('DigitalAssetListComponent', () => {
  let component: DigitalAssetListComponent;
  let fixture: ComponentFixture<DigitalAssetListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DigitalAssetListComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DigitalAssetListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
