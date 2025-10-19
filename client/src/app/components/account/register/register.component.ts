import { Component, inject, OnInit } from '@angular/core';
import { AccountService } from '../../../services/account.service';
import { FormBuilder, FormControl, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { Register } from '../../../models/register.model';

@Component({
  selector: 'app-register',
  imports: [
    FormsModule, ReactiveFormsModule
  ],
  templateUrl: './register.component.html',
  styleUrl: './register.component.scss'
})
export class RegisterComponent implements OnInit {
  accountService = inject(AccountService);
  fB = inject(FormBuilder);

  minDate = new Date();
  maxDate = new Date();

  passwordsNotMatch: boolean | undefined;

  ngOnInit(): void {
    const currentYear = new Date().getFullYear();
    this.minDate = new Date(currentYear - 99, 0, 1);
    this.maxDate = new Date(currentYear - 18, 0, 1);
  }

  registerFg = this.fB.group({
    emailCtrl: ['', [Validators.required, Validators.email]],
    passwordCtrl: ['', [Validators.required]],
    confirmPasswordCtrl: ['', [Validators.required]],
    dateOfBirthCtrl: ['', [Validators.required]]
  });

  get EmailCtrl(): FormControl {
    return this.registerFg.get('emailCtrl') as FormControl;
  }

  get PassWordCtrl(): FormControl {
    return this.registerFg.get('passwordCtrl') as FormControl;
  }

  get ConfirmPasswordCtrl(): FormControl {
    return this.registerFg.get('confirmPasswordCtrl') as FormControl;
  }

  get DateOfBirthCtrl(): FormControl {
    return this.registerFg.get('dateOfBirthCtrl') as FormControl;
  }

  register(): void {
    const dob: string | undefined = this.getDateOnly(this.DateOfBirthCtrl.value);

    if (this.PassWordCtrl.value == this.ConfirmPasswordCtrl.value) {
      let user: Register = {
        email: this.EmailCtrl.value,
        password: this.PassWordCtrl.value,
        confirmPassword: this.ConfirmPasswordCtrl.value,
        dateOfBirth: this.DateOfBirthCtrl.value
      }
    }
  }

  getDateOnly(dob: string | null): string | undefined {
    if (!dob) return undefined;

    let theDob: Date = new Date(dob);
    return new Date(theDob.setMinutes(theDob.getMinutes() - theDob.getTimezoneOffset())).toISOString().slice(0, 10);
  }
}