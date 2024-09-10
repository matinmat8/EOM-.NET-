import { Component, OnInit } from '@angular/core';
import { SongApiService } from '../song-api.service';
import { ActivatedRoute, Router } from '@angular/router';
import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { UpdateSongDto } from '../../dtos/UpdateSongDto.model';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-song-update',
  standalone: true,
  imports: [FormsModule, CommonModule, ReactiveFormsModule],
  templateUrl: './song-update.component.html',
  styleUrl: './song-update.component.css'
})
export class SongUpdateComponent implements OnInit {

  songForm!: FormGroup;
  songId!: number;

  constructor (
    private songApiService: SongApiService,
    private fb: FormBuilder,
    private route: ActivatedRoute,
    private router: Router

  ) {}


  ngOnInit(): void {
    this.songId = +this.route.snapshot.paramMap.get('id')!;
    this.songApiService.getDetail(this.songId).subscribe({
      next: (song) => {
        this.songForm = this.fb.group({
          Id: [song.id, Validators.required],
          Name: [song.music_name, Validators.required],
          Path: [song.music_path, Validators.required],
          GenreId: [song.music_genre, Validators.required],
          AlbumId: [song.album, Validators.required],
          Slug: [song.slug],
          Review: [song.review],
          ReleaseDate: [song.release_date]
        });
      },
      error: (err) => console.error('Error fetching singer details', err)
    });
  }



  onSubmit(): void {
    if (this.songForm.valid) {
      const updateSongDto: UpdateSongDto = this.songForm.value;
      this.songApiService.updateSong(updateSongDto).subscribe({
        next: (response) => {
          console.log('Singer updated successfully', response);
          this.router.navigate(['/singer', response.Id]);
        },
        error: (err) => console.error('Error updating singer', err)
      });
    }
  }
}