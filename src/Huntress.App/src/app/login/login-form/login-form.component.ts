import { Component, Output, EventEmitter, Renderer2, AfterContentInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';

@Component({
  selector: 'or-login-form',
  templateUrl: './login-form.component.html',
  styleUrls: ['./login-form.component.scss']
})
export class LoginFormComponent implements AfterContentInit {

  readonly form = new FormGroup({
    username: new FormControl("Admin", [Validators.required]),
    password: new FormControl("P@ssw0rd", [Validators.required])
  });

  @Output() readonly tryToLogin: EventEmitter<{ username: string, password: string }> = new EventEmitter();

  constructor(private readonly _renderer: Renderer2) { }

  ngAfterContentInit(): void {
    this._renderer.selectRootElement('.login-form__username').focus();
  }
}
