import { Component, Input, OnInit } from '@angular/core';
import { SongApiService } from '../song-api.service';
import { Observable } from 'rxjs';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Song } from '../../models/song.model';
import { ActivatedRoute, RouterLink } from '@angular/router';

@Component({
  selector: 'app-song-detail',
  standalone: true,
  imports: [CommonModule, FormsModule, RouterLink],
  templateUrl: './song-detail.component.html',
  styleUrl: './song-detail.component.css'
})

export class SongDetailComponent implements OnInit {

  @Input() songId: number = 0;

  song: any;
  

  constructor(
    private songApiService: SongApiService,
    private route: ActivatedRoute,
    ) {}


  ngOnInit(): void {
    this.route.params.subscribe(params => {
      const songId = +params['id'];
      this.getSongDetails(songId);
    });
  }

  getSongDetails(songId: number): void {
    this.songApiService.getDetail(songId).subscribe(data => {
      this.song = data;
    });
  }
}
