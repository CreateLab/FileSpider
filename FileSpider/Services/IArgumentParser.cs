using FileSpider.Models;

namespace FileSpider.Services;

public interface IArgumentParser
{
    ArgumentParserModel GetArgumentParserModel(string[] args);
}