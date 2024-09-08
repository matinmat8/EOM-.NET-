import { Routes } from '@angular/router';
import { GenreAddComponentComponent } from './genre/genre-add-component/genre-add-component.component';
import { AddAlbumComponent } from './album/add-album/add-album.component';
import { SongReadComponent } from './song/song-read/song-read.component';
import { SongDetailComponent } from './song/song-detail/song-detail.component';
import { SongCreateComponent } from './song/song-create/song-create.component';
import { SongDeleteComponent } from './song/song-delete/song-delete.component';
import { AddSingerComponent } from './singer/singer-create/singer-create.component';
import { SingerReadComponent } from './singer/singer-read/singer-read.component';
import { SingerDetailComponent } from './singer/singer-detail/singer-detail.component';
import { SingerDeleteComponent } from './singer/singer-delete/singer-delete.component';
import { SingerUpdateComponent } from './singer/singer-update/singer-update.component';


export const routes: Routes = [
    { path: 'songs', component:SongReadComponent },
    { path: 'genre', component: GenreAddComponentComponent },
    { path: 'album', component: AddAlbumComponent},
    { path: 'songs/:id', component: SongDetailComponent },
    { path: 'song/add', component: SongCreateComponent },
    { path: 'song/delete/:id', component: SongDeleteComponent },
    { path: 'singer/add', component:AddSingerComponent},
    { path: 'singer/list', component:SingerReadComponent },
    { path: 'singer/:id', component: SingerDetailComponent },
    { path: 'singer/delete/:id', component:SingerDeleteComponent },
    { path: 'singer/update/:id', component:SingerUpdateComponent }
];
