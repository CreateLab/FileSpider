using System.Security.Cryptography;
using System.Text;
using FileSpider.Models;

namespace FileSpider.Services;

public class WorkService : IWorkService
{
    private IEndService _endService;
    private IQueueService _queueService;

    public WorkService(IQueueService queueService, IEndService endService)
    {
        _queueService = queueService;
        _endService = endService;
    }

    public void StartWork(int threadCount)
    {
        for (var i = 0; i < threadCount; i++)
        {
            var thread = new Thread(Do);
            thread.Start();
        }
    }


    private void Do()
    {
        using var sha256Hash = SHA256.Create();
        var isWork = true;
        while (isWork)
        {
            var data = _queueService.DequeueFileUnit();
            if (data == null)
            {
                isWork = false;
                if (!_endService.IsFileEnd()) continue;
                _endService.SendEnd();
                isWork = false;
            }
            else
            {
                var sha = ComputeSha256Hash(data.Data, sha256Hash);
                var log = new LogUnit
                {
                    Position = data.Position,
                    SHA = sha
                };
                _queueService.EnqueueLogUnit(log);
            }
        }
    }

    private static string ComputeSha256Hash(byte[] data, HashAlgorithm sha256Hash)
    {
        // ComputeHash - returns byte array  
        var bytes = sha256Hash.ComputeHash(data);

        // Convert byte array to a string   
        var builder = new StringBuilder();
        foreach (var t in bytes)
        {
            builder.Append(t.ToString("x2"));
        }

        return builder.ToString();
    }
}