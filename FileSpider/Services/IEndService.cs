namespace FileSpider.Services;

public interface IEndService
{
    public void SendEnd();
    public bool IsEnd();
    public void SendFileEnd();
    public bool IsFileEnd();
}