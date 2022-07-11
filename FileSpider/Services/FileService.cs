using FileSpider.Constants;
using FileSpider.Models;

namespace FileSpider.Services;

public class FileService : IFileService
{
    private readonly IEndService _endService;
    private readonly IQueueService _queueService;

    public FileService(IQueueService queueService, IEndService endService)
    {
        _queueService = queueService;
        _endService = endService;
    }

    // <inheritdoc />
    public void ReadFile(string filePath, int blockSize, int threadCount)
    {
        new Thread(_ => Read(filePath, blockSize, threadCount)).Start();
    }

    private void Read(string filePath, int blockSize, int threadCount)
    {
        using var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
        var isWorking = true;
        var count = 0;

        while (isWorking)
        {
            if (_queueService.CountFileUnit() >= threadCount) continue;
            for (var i = 0; i < ThreadConstants.DataCoefficient * threadCount; i++)
            {
                var buffer = new byte[blockSize];
                var readSize = fileStream.Read(buffer, 0, blockSize);
                if (readSize == 0)
                {
                    isWorking = false;
                    _endService.SendFileEnd();
                    break;
                }

                var unit = new FileUnit
                {
                    Position = count,
                    Data = buffer
                };
                _queueService.EnqueueFileUnit(unit);

                count++;
            }
        }
    }
}