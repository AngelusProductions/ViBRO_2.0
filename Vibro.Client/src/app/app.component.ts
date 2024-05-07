import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {
  title = 'Vibro.Client';
  users: any;

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.http.get('https://localhost:5000/api/users').subscribe({
      next: response => this.users = response,
      error: err => console.error(err),
      complete: () => console.log('Request Completed')
    });
  }
}
