namespace Midterm2Ex.Models;

public class Album
{
    public int IdAlbum { get; set; }
    public string Name { get; set; } = null!;
    public DateTime ReleaseDate { get; set; }
    public int IdStudio { get; set; }
    public Studio Studio { get; set; }

    public ICollection<Song> Songs { get; set; }
}