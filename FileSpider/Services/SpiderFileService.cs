namespace FileSpider.Services;

public class SpiderFileService : ISpiderFileService
{
    private IArgumentParser _argumentParser;
    private IFileService _fileService;

    private ILogService _logService;

    private IWorkService _workService;

    public SpiderFileService(IFileService fileService, IWorkService workService, IArgumentParser argumentParser,
        ILogService logService)
    {
        _fileService = fileService;
        _workService = workService;
        _argumentParser = argumentParser;
        _logService = logService;
    }

    public void Run(string[] args)
    {
        var argumentParserModel = _argumentParser.GetArgumentParserModel(args);
        var threadCount = Environment.ProcessorCount;
        _fileService.ReadFile(argumentParserModel.FileName, argumentParserModel.FileBlockSize, threadCount);
        _workService.StartWork(threadCount);
        _logService.RunLogging();
    }
}