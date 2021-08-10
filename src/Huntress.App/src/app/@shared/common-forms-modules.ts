import { ReactiveFormsModule } from "@angular/forms";
import { MatButtonModule } from "@angular/material/button";
import { MatFormFieldModule } from "@angular/material/form-field";
import { MatInputModule } from "@angular/material/input";
import { MatTabsModule } from "@angular/material/tabs";

export const COMMON_FORMS_MODULES: any[] = [
  ReactiveFormsModule,
  MatTabsModule,
  MatFormFieldModule,
  MatButtonModule,
  MatInputModule
];
