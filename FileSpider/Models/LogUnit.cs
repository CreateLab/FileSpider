namespace FileSpider.Models;

public record LogUnit
{
    public int Position { get; init; }
    public int SHA { get; init; }
}