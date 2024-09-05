import { Component } from '@angular/core';
import { SongApiService } from '../song-api.service';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-song-create',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './song-create.component.html',
  styleUrl: './song-create.component.css'
})
export class SongCreateComponent {

  song: any;

  constructor(private songApiService: SongApiService) {}


  onSubmit(): void {
    this.songApiService.createSong(this.song).subscribe(response => {
      console.log('Song added successfully', response);
    })
  }

}
