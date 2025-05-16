import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AppUser } from '../Models/app-user.model';

@Injectable({
  providedIn: 'root'
})
export class AccountService {
  http = inject(HttpClient);

  register(user: AppUser): Observable<AppUser> {
    let userResponse: Observable<AppUser>
    this.http.post<AppUser>('http://localhost:5000/api/account/register', user);

    return userResponse;
  }

  getAllMember(): Observable<AppUser[]> {
    let membersResponse: Observable<AppUser[]>
    this.http.get<AppUser[]>('http://localhost:5000/api/account/get-all');

    return membersResponse;
  }
}