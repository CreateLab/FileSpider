namespace FileSpider.Services;

class EndService : IEndService
{
    private object _endLock = new object();
    private int _endTreadsCount;
    private bool _isEnd;
    private bool _isFileEnd;

    public void SendEnd()
    {
        lock (_endLock)
        {
            _endTreadsCount++;
        }
    }

    public bool IsEnd()
    {
        var c = _endTreadsCount;
        return c >= Environment.ProcessorCount;
    }

    public void SendFileEnd()
    {
        _isFileEnd = true;
    }

    public bool IsFileEnd()
    {
        return _isFileEnd;
    }
}