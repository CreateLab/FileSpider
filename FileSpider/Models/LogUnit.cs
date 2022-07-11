namespace FileSpider.Models;

public record LogUnit
{
    public int Position { get; init; }
    public string SHA { get; init; }
}