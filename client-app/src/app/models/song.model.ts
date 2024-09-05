import { Profile } from './profile.model';
import { Album } from './album.model';
import { Genre } from './genre.model';
import { Singer } from './singer.model';
import { PlayList } from './playlist.model';

export interface Song {
  id: number;
  user?: Profile;
  album?: Album;
  singers: Singer[];
  music_name: string;
  music_genre?: Genre;
  release_date: Date;
  pub_date: Date;
  cover_art: string;
  imagefile: File;
  music_path: string;
  music_file: File;
  lyrics?: string;
  review?: string;
  slug: string;
  views: number;
  tags: string[];
  playlists: PlayList[];
}
