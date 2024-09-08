import { Component } from '@angular/core';
import { SongApiService } from '../song-api.service';
import { CommonModule } from '@angular/common';
import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule } from '@angular/forms';

@Component({
  selector: 'app-song-create',
  standalone: true,
  imports: [CommonModule, FormsModule, ReactiveFormsModule],
  templateUrl: './song-create.component.html',
  styleUrl: './song-create.component.css'
})
export class SongCreateComponent {
  songForm: FormGroup;

  constructor(private fb: FormBuilder, private songApiService: SongApiService) {
    this.songForm = this.fb.group({
      UserName: [''],
      MusicName: [''],
      GenreId: [''],
      ReleaseDate: [''],
      PublishDate: [''],
      ImageFile: [null],
      MusicFile: [null],
      Lyrics: [''],
      Review: [''],
      Tag: [''],
      Slug: [''],
      AlbumId: [''],
    });
  }

  onFileChange(event: any, field: string) {
    const file = event.target.files[0];
    this.songForm.patchValue({ [field]: file });
  }

  onSubmit() {
    const formData = new FormData();
    Object.keys(this.songForm.controls).forEach(key => {
      const value = this.songForm.get(key)?.value;
      console.log(`${key}: ${value}`);
      formData.append(key, value);
    });

    this.songApiService.createSong(formData).subscribe({
      next: (data) => { console.log(data);
        this.songForm = data;
       },
      error: (error) => { console.error(error); },
      complete: () => { console.log('Complete'); }
    });
  }

}