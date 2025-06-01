import { Component, inject } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { AccountService } from './services/account.service';
import { AppUser } from './models/app-user.model';
import { FormBuilder, FormControl, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-root',
  imports: [
    RouterOutlet,
    FormsModule, ReactiveFormsModule
  ],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent {
  accountService = inject(AccountService);
  fB = inject(FormBuilder);
  appUser: AppUser | undefined;
  members: AppUser[] | undefined;

  registerFg = this.fB.group({
    emailCtrl: ['', [Validators.required, Validators.email]],
    nameCtrl: ''
  });

  get EmailCtrl(): FormControl {
    return this.registerFg.get('emailCtrl') as FormControl;
  }

  get NameCtrl(): FormControl {
    return this.registerFg.get('nameCtrl') as FormControl;
  }

  register(): void {
    let userIn: AppUser = {
      email: this.EmailCtrl.value,
      name: this.NameCtrl.value
    }

    let userRes$: Observable<AppUser> = this.accountService.register(userIn);

    userRes$.subscribe({
      next: (response => {
        this.appUser = response;
        console.log(this.appUser);
      })
    })
  }

  getAll(): void {
    let membersRes$: Observable<AppUser[]> = this.accountService.getAll();

    membersRes$.subscribe({
      next: (res => {
        this.members = res;

        console.log(res);
      })
    });
  }
}