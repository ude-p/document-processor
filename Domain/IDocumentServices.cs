namespace Domain;

public interface IDocumentRepository
{
    Task<Document?> GetByIdAsync(Guid Id);
    Task SaveAsync(Document document);
}

public interface IDocumentParserService
{

}

public interface IDocumentFormatterService
{

}

public interface IPdfGeneratorService
{

}