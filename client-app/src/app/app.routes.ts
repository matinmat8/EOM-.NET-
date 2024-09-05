import { Routes } from '@angular/router';
import { GenreAddComponentComponent } from './genre/genre-add-component/genre-add-component.component';
import { AddAlbumComponent } from './album/add-album/add-album.component';
import { SongReadComponent } from './song/song-read/song-read.component';
import { SongDetailComponent } from './song/song-detail/song-detail.component';
import { SongCreateComponent } from './song/song-create/song-create.component';
import { SongDeleteComponent } from './song/song-delete/song-delete.component';

export const routes: Routes = [
    { path: 'songs', component:SongReadComponent },
    { path: 'genre', component: GenreAddComponentComponent },
    { path: 'album', component: AddAlbumComponent},
    { path: 'songs/:id', component: SongDetailComponent },
    { path: 'song/add', component: SongCreateComponent },
    { path: 'song/delete/:id', component: SongDeleteComponent }
];
