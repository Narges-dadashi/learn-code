import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AppUser } from '../models/app-user.model';

@Injectable({
  providedIn: 'root'
})
export class AccountService {
  http = inject(HttpClient);
  private readonly _baseApiUrl: string = 'http://localhost:5000/api/';

  register(user: AppUser): Observable<AppUser> {
    let userResponse$: Observable<AppUser> =
      this.http.post<AppUser>(this._baseApiUrl + 'account/register', user);

    return userResponse$;
  }

  getAll(): Observable<AppUser[]> {
    let membersResponse$: Observable<AppUser[]> =
      this.http.get<AppUser[]>(this._baseApiUrl + 'account/get-all');

    return membersResponse$;
  }
}