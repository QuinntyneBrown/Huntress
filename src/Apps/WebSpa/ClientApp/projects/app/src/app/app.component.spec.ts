// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AppComponent } from './app.component';

describe('AppComponent', () => {
  let component: AppComponent;
  let fixture: ComponentFixture<AppComponent>;

  beforeEach(async () => {
    // ARRANGE
    await TestBed.configureTestingModule({
      imports: [ AppComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AppComponent);
    component = fixture.componentInstance;
    // ACT
    fixture.detectChanges();
  });

    // Test ID

  it('should create', () => {
    // ASSERT
    expect(component).toBeTruthy();
  });
});

