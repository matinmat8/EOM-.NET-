import { Song } from "../models/song.model"

export interface CreateSongDto {
    song: Song;
    SingerIds: number[];
}