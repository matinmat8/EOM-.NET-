
namespace EomWebApiProject.Models {
    public class AlbumSong {
        public int AlbumId { get; set; }
        public Album Album { get; set; }
        public int SongId { get; set; }
        public Song Song { get; set; }
    }
}