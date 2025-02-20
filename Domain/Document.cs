using System.Dynamic;

namespace Domain;

public class Document(string fileName, FileType fileType, string rawContent)
{
    public Guid Id { get; } = Guid.NewGuid();
    public string FileName { get; } = fileName;
    public FileType FileType { get; } = fileType;
    public string RawContent { get; } = rawContent;
    public DateTime CreatedAt { get; } = DateTime.UtcNow;
    public DocumentStatus Status { get; private set; } = DocumentStatus.Pending;

    public void MarkAsProcessed() => Status = DocumentStatus.Completed;
}

// Value Objects
public enum FileType
{
    JSON, XML, CSV
}

public enum DocumentStatus
{
    Pending, Processing, Completed, Failed
}
