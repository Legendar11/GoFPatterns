using Visitor.Documents;

namespace Visitor;

/// <summary>
/// Interface specifies methods for all class in hierarchy.
/// It allows to execute specific method via ad-hoc polymorphism.
/// </summary>
internal interface IVisitor
{
    void Visit(TxtDocument document);
    void Visit(DocxDocument document);
    void Visit(XlsxDocument document);
}
