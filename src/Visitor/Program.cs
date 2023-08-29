
using Visitor;
using Visitor.Documents;

IVisitor visitor = new DocumentVisitor();
var documentManager = new TxtDocument("DocumentFiles/test.txt");

documentManager.Accept(visitor);