import { Component } from '@angular/core';
import { AlbumApiService } from '../album-api.service';
import { Album } from '../../models/album.model';
import { Genre } from '../../models/genre.model';
import { FormsModule } from '@angular/forms';


@Component({
  selector: 'app-add-album',
  standalone: true,
  imports: [FormsModule,],
  templateUrl: './add-album.component.html',
  styleUrl: './add-album.component.css'
})
export class AddAlbumComponent {

  constructor (private albumApiService: AlbumApiService) {}

  // singers: Singer = {}
  // genre: Genre = {GenreName: "Rock"};
  album: Album = {AlbumName: "", TrackCount: 2 }
  

  onSubmit() {
    this.albumApiService.addAlbum(this.album).subscribe(
      response => {
        console.log('Genre added successfully', response)
      },
      error => console.error('Error:', error)
    )
  }
}
