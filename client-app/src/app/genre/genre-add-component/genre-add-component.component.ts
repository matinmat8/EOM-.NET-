import { Component } from '@angular/core';
import { Genre } from '../../models/genre.model';
import { GenreServiceService } from '../genre-service.service';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-genre-add-component',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './genre-add-component.component.html',
  styleUrl: './genre-add-component.component.css'
})
export class GenreAddComponentComponent {

  constructor(private genreService:GenreServiceService) {}

  genre: Genre = {GenreName: ""};

  onSubmit() {
    this.genreService.addGenre(this.genre)
    .subscribe(response => {
      console.log('Genre added successfully', response);
    });  }

  }

