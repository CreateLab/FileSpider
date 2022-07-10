namespace FileSpider.Services;

public interface IFileService
{
    /// <summary>
    /// Считывает поблочно файл
    /// </summary>
    /// <param name="filePath"></param>
    /// <param name="blockSize"></param>
    /// <returns></returns>
    public void ReadFile(string filePath, int blockSize, int threadCount);
}

class FileService : IFileService
{
}