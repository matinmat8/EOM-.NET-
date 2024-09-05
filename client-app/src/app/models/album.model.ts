import { Genre } from './genre.model';
import { Singer } from './singer.model';
import { Song } from './song.model';

export interface Album {
  // id: number;
  AlbumName: string;
  // singer?: Singer;
  // songs?: Song[];
  genre?: Genre;
  // release_date: Date;
  TrackCount: number;
}
