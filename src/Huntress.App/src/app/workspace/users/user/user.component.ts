import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { User, UserService } from '@api';
import { Observable } from 'rxjs';
import { map, switchMap } from 'rxjs/operators';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.scss']
})
export class UserComponent {

  public roles: string[] = [
    "Admin",
    "Customer"
  ];

  public has(user: User, role:string): boolean {
    return user.roles.filter(x => x.name == role).length > 0;
  }

  public handleRoleClick(user: User, role:string) {

  }

  public vm$: Observable<any> = this._activatedRoute
  .paramMap
  .pipe(
    map(paramMap => paramMap.get("id")),
    switchMap(userId => this._userService.getById({ userId })),
    map(user => {

      const form = new FormGroup({
        username: new FormControl(user.username,[Validators.required])
      });

      return {
        user,
        form
      };
    })
  );

  constructor(
    private readonly _userService: UserService,
    private readonly _activatedRoute: ActivatedRoute
  ) { }

}
