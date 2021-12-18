import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HtmlContentSectionComponent } from './html-content-section.component';

describe('HtmlContentSectionComponent', () => {
  let component: HtmlContentSectionComponent;
  let fixture: ComponentFixture<HtmlContentSectionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ HtmlContentSectionComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(HtmlContentSectionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
