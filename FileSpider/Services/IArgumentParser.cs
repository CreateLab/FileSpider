using FileSpider.Models;

namespace FileSpider.Services;

public interface IArgumentParser
{
    /// <summary>
    /// Parse arguments from command line.
    /// </summary>
    /// <param name="args"></param>
    /// <returns></returns>
    ArgumentParserModel GetArgumentParserModel(string[] args);
}