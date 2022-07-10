namespace FileSpider.Services;

public interface ISpiderFileService
{
    /// <summary>
    /// Запускает приложение обработки файла
    /// </summary>
    void Run(string[] args);
}