using FileSpider.Models;

namespace FileSpider.Services;

public interface IQueueService
{
    void EnqueueFileUnit(FileUnit fileUnit);
    FileUnit DequeueFileUnit();
    int CountFileUnit();
}

class QueueService : IQueueService
{
}