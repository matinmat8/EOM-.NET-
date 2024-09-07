import { Component, OnInit } from '@angular/core';
import { SingerApiService } from '../singer-api.service';
import { Singer } from '../../models/singer.model';
import { RouterLink } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-singer-read',
  standalone: true,
  imports: [RouterLink, CommonModule, FormsModule],
  templateUrl: './singer-read.component.html',
  styleUrl: './singer-read.component.css'
})
export class SingerReadComponent implements OnInit {


  singers: Singer[] = [];


  constructor (private singerApiService: SingerApiService) {}


  ngOnInit(): void {
      this.singerApiService.getSingers().subscribe({
        next: (data) => {
          console.log(data);
          this.singers = data;
        },
        error: (error) => { console.error(error); },
        complete: () => { console.log('Complete'); }
      }
      )
  }
}
