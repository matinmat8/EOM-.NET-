
export interface CreateSingerDto{
    Id: number;
    Name: string;
    GenreId: number;
    AlbumId: number;
    // SongIds: number[]; 
    Birth?: Date;
    Death?: Date;
    AboutSinger?: string;
    }
