import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DigitalAssetEditorComponent } from './digital-asset-editor.component';

describe('DigitalAssetEditorComponent', () => {
  let component: DigitalAssetEditorComponent;
  let fixture: ComponentFixture<DigitalAssetEditorComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DigitalAssetEditorComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DigitalAssetEditorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
