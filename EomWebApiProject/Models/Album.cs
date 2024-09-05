

namespace EomWebApiProject.Models {
    public class Album {
        public int Id { get; set ;}

        public int? SingerId { get; set; }

        public Singer? Singer { get; set; }

        public List<Song>? Songs { get; set; }

        public int? GenreId { get; set; }
        public Genre? Genre { get; set; }
        
        public string AlbumName { get; set; }

        public DateOnly ReleaseDate { get; set; }
        
        public int TrackCount { get; set; }
    }
}