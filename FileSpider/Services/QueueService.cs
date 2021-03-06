using FileSpider.Models;

namespace FileSpider.Services;

class QueueService : IQueueService
{
    private readonly Queue<FileUnit?> _fileQueue = new Queue<FileUnit>();
    private readonly Queue<LogUnit?> _logQueue = new Queue<LogUnit>();
    private object _fileLock = new object();
    private object _logLock = new object();

    public void EnqueueFileUnit(FileUnit fileUnit)
    {
        lock (_fileLock)
        {
            _fileQueue.Enqueue(fileUnit);
        }
    }

    /// <summary>
    /// Try Dequeue a file unit from the queue.
    /// </summary>
    /// <returns></returns>
    public FileUnit? DequeueFileUnit()
    {
        lock (_fileLock)
        {
            return _fileQueue.Count > 0 ? _fileQueue.Dequeue() : null;
        }
    }

    public int CountFileUnit()
    {
        lock (_fileLock)
        {
            return _fileQueue.Count;
        }
    }

    public void EnqueueLogUnit(LogUnit fileUnit)
    {
        lock (_logLock)
        {
            _logQueue.Enqueue(fileUnit);
        }
    }

    public LogUnit? DequeueLogUnit()
    {
        lock (_logLock)
        {
            return _logQueue.Count > 0 ? _logQueue.Dequeue() : null;
        }
    }
}