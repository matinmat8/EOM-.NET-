

namespace EomWebApiProject.Models {
    public class PlayList {
        
        public int Id { get; set; }

        public string? UserName { get; set; }

        public int GenreId { get; set; }

        public Genre? Genre { get; set; }

        public string PlayListName { get; set; }

        public string? Description { get; set; }

        public ICollection<PlaylistSong> PlaylistSongs { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime UpdatedAt { get; set; }
    }
}