namespace FileSpider.Services;

class LogService : ILogService
{
    private IEndService _endService;
    private IQueueService _queueService;

    public LogService(IQueueService queueService, IEndService endService)
    {
        _queueService = queueService;
        _endService = endService;
    }

    public void RunLogging()
    {
        var t = new Thread(Log);
        t.Start();
        t.Join();
    }

    private void Log()
    {
        var isWorking = true;
        while (isWorking)
        {
            var log = _queueService.DequeueLogUnit();
            if (log != null)
            {
                Console.WriteLine("Position: {0} SHA {1}", log.Position, log.SHA);
            }
            else
            {
                if (_endService.IsEnd())
                {
                    isWorking = false;
                }
            }
        }
    }
}