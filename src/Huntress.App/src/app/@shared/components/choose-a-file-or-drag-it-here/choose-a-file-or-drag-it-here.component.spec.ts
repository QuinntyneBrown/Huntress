import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ChooseAFileOrDragItHereComponent } from './choose-a-file-or-drag-it-here.component';

describe('ChooseAFileOrDragItHereComponent', () => {
  let component: ChooseAFileOrDragItHereComponent;
  let fixture: ComponentFixture<ChooseAFileOrDragItHereComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ChooseAFileOrDragItHereComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ChooseAFileOrDragItHereComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
