namespace Midterm2Ex.Models;

public class Studio
{
    public int IdStudio { get; set; }
    public string Name { get; set; } = null!;

    public ICollection<Album> Albums { get; set; }
}