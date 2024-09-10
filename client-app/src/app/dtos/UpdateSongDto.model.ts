export interface UpdateSongDto {

    Id: number,
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
    }
    