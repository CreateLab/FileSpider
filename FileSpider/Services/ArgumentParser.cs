using FileSpider.Models;

namespace FileSpider.Services;

class ArgumentParser : IArgumentParser
{
    public ArgumentParserModel GetArgumentParserModel(string[] args)
    {
        var argumentParserModel = new ArgumentParserModel
        {
            FileName = args[0],
            FileBlockSize = int.Parse(args[1]),
        };
        return argumentParserModel;
    }
}