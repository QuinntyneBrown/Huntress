import { ComponentFixture, TestBed } from '@angular/core/testing';

import { WorkspaceFooterComponent } from './workspace-footer.component';

describe('WorkspaceFooterComponent', () => {
  let component: WorkspaceFooterComponent;
  let fixture: ComponentFixture<WorkspaceFooterComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ WorkspaceFooterComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(WorkspaceFooterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
