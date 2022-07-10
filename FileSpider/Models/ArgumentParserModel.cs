namespace FileSpider.Models;

public record ArgumentParserModel
{
    public string FileName { get; init; }
    public int FileBlockSize { get; init; }
}