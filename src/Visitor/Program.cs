using Visitor;
using Visitor.Documents;

// Software design pattern Visitor:
// Describes an operation to be performed on each object from some
// structure.Visitor template Allows you to define a new operation, not
// by changing the classes of these objects.

// Create a visitor
IVisitor visitor = new DocumentVisitor();

// Iterate through objects in one hierarchy
foreach (var document in new IDocument[]
{
    new TxtDocument("DocumentFiles/test.txt"),
    new DocxDocument("DocumentFiles/test.docx"),
    new XlsxDocument("DocumentFiles/test.xlsx")
})
{
    // Execute double dispatching
    document.Accept(visitor);
}

// Note: pattern allows to visit any object which can accept IVisitor,
// hierarchy here is common case for pattern VIsitor demonstration.

// C# allows to execute double dispatching via dynamic
dynamic txtDynamic = new TxtDocument("DocumentFiles/test.txt");
dynamic visitorDynamic = new DocumentVisitor();
visitorDynamic.Visit(txtDynamic);