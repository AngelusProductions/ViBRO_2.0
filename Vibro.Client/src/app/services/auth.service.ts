import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { LoginResponseDto } from '../models/dto/login-response.dto';
import { apiUrl } from '../config/environments';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  constructor(private http: HttpClient) { }

  login(username: string, password: string): Observable<LoginResponseDto> {
    debugger
    return this.http.post<LoginResponseDto>(`${apiUrl}/api/auth/login`, { username, password });
  }
}
