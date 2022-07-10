namespace FileSpider.Models;

public record FileUnit
{
    public int Position { get; init; }
    public byte[] Data { get; init; }
}