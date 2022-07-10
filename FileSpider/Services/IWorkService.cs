namespace FileSpider.Services;

public interface IWorkService
{
    void StartWork(int threadCount);
}

class WorkService : IWorkService
{
}