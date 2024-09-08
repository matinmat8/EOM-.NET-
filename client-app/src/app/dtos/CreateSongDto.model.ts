import { Song } from "../models/song.model"

export interface CreateSongDto {

    UserName: string;
    MusicName: string;
    GenreId: number;
    ReleaseDate?: Date;
    PublishDate: Date;
    ImageFile: File;
    MusicFile: File;
    Lyrics: Text;
    Review: Text;
    Tag?: string;
    Slug?: string;
    AlbumId: number
    // public List<int/> SingerIds { get; set; }
    }
    