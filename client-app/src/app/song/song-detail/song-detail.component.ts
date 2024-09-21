import { Component, Input, OnInit } from '@angular/core';
import { SongApiService } from '../song-api.service';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ActivatedRoute, RouterLink } from '@angular/router';
import { DomSanitizer, SafeUrl } from '@angular/platform-browser';
import { Observable } from 'rxjs';
import { response } from 'express';

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
  songFileUrl!: SafeUrl;
  // audioSource: string | undefined;

  audioUrl: string | null = null;
  

  constructor(
    private songApiService: SongApiService,
    private route: ActivatedRoute,
    private sanitizer: DomSanitizer
    ) {}


  ngOnInit(): void {
    this.route.params.subscribe(params => {
      const songId = +params['id'];
      this.getDetail(songId);
    });}

    getDetail (id: number) {
      this.songApiService.getDetail(id).subscribe(response => {
        this.song = response;
        console.log(this.song);
        this.loadAudio(id);
      })
    }

    loadAudio(id: number): void {
      this.songApiService.fetchSongFile(id).subscribe({
        next: (blob) => {
          this.songFileUrl = URL.createObjectURL(blob);
          console.log(this.songFileUrl)
         },
        error: (error) => {console.error('Error loading audio', error);},
      });
    }
  }
