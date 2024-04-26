import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, throwError, } from 'rxjs';
import { catchError, tap } from 'rxjs/operators';

import { apiUrl } from '../config/environments';
import { Vibe } from '../models/vibe.interface';

@Injectable({
  providedIn: 'root'
})
export class VibesService {

  constructor(private http: HttpClient) { }

  getAll(): Observable<Vibe[]> {
    return this.http.get<Vibe[]>(`${apiUrl}/api/vibes`)
      .pipe(
        tap(_ => {
          debugger;
          return new Observable();
        }),
        catchError(error => {
          debugger
          return throwError(() => new Error(`Error fetching all vibes: ${error}`));
        })
      );
  }
}
