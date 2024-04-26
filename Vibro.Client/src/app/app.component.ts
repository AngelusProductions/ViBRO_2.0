import { Component, OnInit } from '@angular/core';

import { Vibe } from './models/vibe.interface';
import { VibesService } from './services/vibes.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit{
  vibes: Vibe[] = [];

  constructor(private vibesService: VibesService) {}

  ngOnInit() {
    this.vibesService.getAll().subscribe({
      next: (data: Vibe[]) => {
        this.vibes = data;  // Assign the data to the component's property
      },
      error: (error: any) => {
        console.error('Failed to get vibes:', error);
      }
    });
  }
}
