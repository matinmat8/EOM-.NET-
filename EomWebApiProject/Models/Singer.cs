
namespace EomWebApiProject.Models {
    public class Singer {

        public int Id { get; set; }
        public string Name{ get; set; }
        public int GenreId { get; set; }
        public Genre Genre { get; set; }

        // public int AlbumId { get; set; }
        public Album Album { get; set; }
        public ICollection<SongSinger> SongSingers { get; set; }
        
        public DateOnly? Birth { get; set; }
        public DateOnly? Death { get; set; }
        public string? AboutSinger { get; set; }

    }
}