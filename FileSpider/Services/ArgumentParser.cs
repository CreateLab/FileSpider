using CommandLine;
using FileSpider.Models;

namespace FileSpider.Services;

class ArgumentParser : IArgumentParser
{
    public ArgumentParserModel GetArgumentParserModel(string[] args)
    {
        var argumentParserModel = Parser.Default.ParseArguments<ArgumentParserModel>(args).Cast<ArgumentParserModel>();
        return argumentParserModel;
    }
}