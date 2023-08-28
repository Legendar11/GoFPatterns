using Strategy;
using Strategy.Processors;

// Software design pattern Strategy:
// Defines a family of algorithms, encapsulates each one, and makes their interchangeable.
// The strategy allows you to change the algorithms regardless of the clients who use them.

IDocumentManager documentManager;
Dictionary<string, object> placeholdersData = new() { ["Id"] = Guid.NewGuid().ToString() };

// Set Processor via constructor
documentManager = new DocumentManager(new TextProcessor());
documentManager.ProcessDocument("Documents/test.txt", "Documents/test_output.txt", placeholdersData);

// Change Processor via property
documentManager.Processor = new DocxDocument();
documentManager.ProcessDocument("Documents/test.docx", "Documents/test_output.docx", placeholdersData);

documentManager.Processor = new XlsxDocument();
documentManager.ProcessDocument("Documents/test.xlsx", "Documents/test_output.xlsx", placeholdersData);