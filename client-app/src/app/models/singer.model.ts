import { Genre } from './genre.model';
import { Album } from './album.model';
import { Song } from './song.model';

export interface Singer {
  id: number;
  name: string;
  genre?: Genre;
  album: Album;
  songs: Song[];
  birth?: Date;
  death?: Date;
  about_singer?: string;
}
