
namespace EomWebApiProject.Models {
    public class Genre {
        public int Id { get; set; }
        public string GenreName { get; set; }

        public string? GenreDiscription { get; set; }

        public ICollection<Singer>? Singers { get; set; }
        public ICollection<Song>? Songs { get; set; }
        public ICollection<Album>? Albums { get; set; }
        public ICollection<PlayList>? PlayLists { get; set; }
    }
}
