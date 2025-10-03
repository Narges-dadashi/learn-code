import { HttpClient } from '@angular/common/http';
import { inject, Injectable, PLATFORM_ID } from '@angular/core';
import { environment } from '../../environments/environment.development';
import { Router } from '@angular/router';
import { Register } from '../models/register.model';
import { Observable } from 'rxjs';
import { LoggedIn } from '../models/logged-in.model';

@Injectable({
  providedIn: 'root'
})
export class AccountService {
  http = inject(HttpClient);
  private readonly _baseApiUrl: string = environment.apiUrl + 'api/';
  platformId = inject(PLATFORM_ID);
  router = inject(Router);

  register(userInput: Register): Observable<LoggedIn | null> {
    return this.http.post<LoggedIn>(this._baseApiUrl + 'account/register', userInput);
  }
}