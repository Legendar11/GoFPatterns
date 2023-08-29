using Visitor.Documents;

namespace Visitor;

internal interface IVisitor
{
    void Visit(TxtDocument document);
    void Visit(DocxDocument document);
    void Visit(XlsxDocument document);
}
