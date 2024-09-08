

namespace EomWebApiProject.Models {
    public class Song {
        public int Id { get; set; }
        
        public string UserName { get; set; }

        public string MusicName { get; set; }
        
        public int GenreId { get; set; }

        public Genre Genre { get; set; }

        public DateOnly? ReleaseDate { get; set; }

        public DateTime? PublishDate { get; set; }
        
        public string? ImagePath { get; set; }
        
        public IFormFile? ImageFile { get; set; }

        public string MusicPath { get; set; }

        // We Don't save music itself in the database, instead we do save its path in our database
        public IFormFile MusicFile { get; set; }
        
        
        public string? Lyrics { get; set; }

        public string? Review { get; set; }

        public int Views { get; set; }

        public string? Tag { get; set; }

        public string? Slug { get; set; }
        
        public ICollection<PlaylistSong>? PlaylistSongs { get; set; }

        public int AlbumId { get; set; }
        public Album Album { get; set; }
        public ICollection<SongSinger> SongSingers { get; set; }

    }
}