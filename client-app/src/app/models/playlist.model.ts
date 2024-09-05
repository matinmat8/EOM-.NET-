import { Profile } from './profile.model';
import { Genre } from './genre.model';
import { Song } from './song.model';

export interface PlayList {
  id: number;
  user?: Profile;
  genre?: Genre;
  play_list_name: string;
  description?: string;
  songs: Song[];
  created_at: Date;
  updated_at: Date;
}
