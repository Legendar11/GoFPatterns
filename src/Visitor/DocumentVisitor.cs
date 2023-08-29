using Visitor.Documents;

namespace Visitor;

internal class DocumentVisitor : IVisitor
{
    public void Visit(TxtDocument document)
    {
        Console.WriteLine($"""
        Visit {nameof(TxtDocument)}:
            Name: {document.Name}
            Content Length: {document.Content.Length}
        -----------------------------------------------
        """);
    }

    public void Visit(DocxDocument document)
    {
        Console.WriteLine($"""
        Visit {nameof(DocxDocument)}:
            Name: {document.Name}
            Content Length: {document.Content.Length}
            Count parapgraphs: {document.OriginalDocument.Paragraphs.Count}
            Count tables: {document.OriginalDocument.Tables.Count}
            Count pictures: {document.OriginalDocument.AllPictures.Count}
        -----------------------------------------------
        """);
    }

    public void Visit(XlsxDocument document)
    {
        Console.WriteLine($"""
        Visit {nameof(XlsxDocument)}:
            Name: {document.Name}
            Content Length: {document.Content.Length}
            Count sheets: {document.OriginalDocument.Count}
            Active sheet index: {document.OriginalDocument.ActiveSheetIndex}
            Workbook type: {document.OriginalDocument.WorkbookType}
        -----------------------------------------------
        """);
    }
}
