import { Routes } from '@angular/router';
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
import { GenreCreateComponent } from './genre/genre-create/genre-create.component';
import { SongUpdateComponent } from './song/song-update/song-update.component';
import { LoginComponent } from './authentication/login/login.component';
import { SignUpComponent } from './authentication/sign-up/sign-up.component';
import { AuthGuard } from './auth.guard';


export const routes: Routes = [
    { path: '', component:SongReadComponent },
    { path: 'genre', component: GenreCreateComponent },
    { path: 'album', component: AddAlbumComponent},
    { path: 'song/:id', component: SongDetailComponent },
    { path: 'song/add', component: SongCreateComponent, canActivate: [AuthGuard] },
    { path: 'song/update/:id', component: SongUpdateComponent },
    { path: 'song/delete/:id', component: SongDeleteComponent },
    { path: 'singer/add', component:AddSingerComponent, canActivate: [AuthGuard]},
    { path: 'singer/list', component:SingerReadComponent },
    { path: 'singer/:id', component: SingerDetailComponent },
    { path: 'singer/delete/:id', component:SingerDeleteComponent, canActivate: [AuthGuard] },
    { path: 'singer/update/:id', component:SingerUpdateComponent, canActivate: [AuthGuard] },
    {path: 'login', component:LoginComponent},
    {path: 'signup', component:SignUpComponent}
];
