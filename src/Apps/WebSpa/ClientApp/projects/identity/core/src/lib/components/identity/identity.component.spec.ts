// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

    // Test ID

import { ComponentFixture, TestBed } from '@angular/core/testing';

import { IdentityComponent } from './identity.component';

describe('IdentityComponent', () => {
  let component: IdentityComponent;
  let fixture: ComponentFixture<IdentityComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ IdentityComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(IdentityComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

    // ARRANGE
    // ACT
    // ASSERT

