import { Component, OnInit } from '@angular/core';
import { SongApiService } from '../song-api.service';
import { response } from 'express';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { Song } from '../../models/song.model';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-song-read',
  standalone: true,
  imports: [FormsModule, CommonModule, RouterLink],
  templateUrl: './song-read.component.html',
  styleUrl: './song-read.component.css'
})
export class SongReadComponent implements OnInit {

  songs: any[] = [];

  constructor(private songApiService: SongApiService) {}


  ngOnInit(): void {
    this.songApiService.getData().subscribe({
      next: (data) => { console.log(data);
        this.songs = data;
       },
      error: (error) => { console.error(error); },
      complete: () => { console.log('Complete'); }
    });
  }

  selectSong(id: number){
    this.songApiService.getDetail(id)
  }
}
