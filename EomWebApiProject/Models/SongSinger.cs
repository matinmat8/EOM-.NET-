
namespace EomWebApiProject.Models {
    public class SongSinger {
        public int SingerId { get; set; }
        public Singer Singer { get; set; }
        public int SongId { get; set; }
        public Song Song { get; set; }
    }
}