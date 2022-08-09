using System.Reflection;
 
namespace TestProject1;

public class PrimeGeneratorTests
{
    private const string GoldenMasterPath = @"gold.txt";
    private const string OutputsPath      = @"out.txt";
    private StreamWriter _streamWriter;
    
    private static string BinaryDirectoryPath =>
        Path.GetDirectoryName(Assembly.GetExecutingAssembly()
                .GetName()
                .CodeBase)
            ?.Replace(@"file:", "");

    [Test]
    public void Main_Should_Output_Equivalent_Of_Golden_Master()
    {
        // Arrange
        RedirectConsoleOutputToLeadFile();

        // Act
        PrimePrinter.Main(new string[0]);

        // Assert
        ResetConsoleOutput();
        AssertTextFilesHaveSameContent(GoldenMasterPath, OutputsPath);
    }

    private static void AssertTextFilesHaveSameContent(string expectedFilePath, string actualFilePath)
    {
        var expectedLines   = File.ReadAllLines(Path.Combine(BinaryDirectoryPath, expectedFilePath));
        var actualLines     = File.ReadAllLines(Path.Combine(BinaryDirectoryPath, actualFilePath));
        var unexpectedLines = actualLines.Except(expectedLines);
       Assert.IsEmpty(unexpectedLines);
        // Check.That(unexpectedLines).IsEmpty();
    }

    private void RedirectConsoleOutputToLeadFile()
    {
        Directory.SetCurrentDirectory(BinaryDirectoryPath);
        _streamWriter = new StreamWriter(OutputsPath)
        {
            AutoFlush = true
        };
        Console.SetOut(_streamWriter);
    }

    private void ResetConsoleOutput()
    {
        _streamWriter.Close();
        Console.SetOut(Console.Out);
    }
}