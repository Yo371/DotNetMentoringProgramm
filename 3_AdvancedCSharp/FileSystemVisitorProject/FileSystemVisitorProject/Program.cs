using FileSystemVisitorLibrary;

try
{
    var inputLine = Console.ReadLine();
    ArgumentNullException.ThrowIfNull(inputLine);

    var splittedLine = inputLine.Split(" ");
    var path = splittedLine[0];

    Predicate<FileSystemInfo>? filter = null;
    if (splittedLine.Length == 3)
    {
        filter = FileSystemVisitorConsole.GetFilterByFlag(splittedLine[1], splittedLine[2]);
    }

    IFileSystemVisitor fileSystemVisitor = new FileSystemVisitorConsole(path, filter);

    fileSystemVisitor.StartEvent += (_, _) => Console.WriteLine("Start:");
    fileSystemVisitor.EndEvent += (_, _) => Console.WriteLine("End:");
    fileSystemVisitor.FileFoundEvent += (_, item) => Console.Write($"File Found: {item.Name}\n");
    fileSystemVisitor.DirectoryFoundEvent += (_, item) => Console.Write($"Folder Found: {item.Name}\n");


    fileSystemVisitor.FilteredDirectoryFoundEvent += (_, item) =>
    {
        fileSystemVisitor.SkipNext();
        Console.Write("Filtered folder SKIPPED\n");
    };

    fileSystemVisitor.FilteredFileFoundEvent += (_, item) =>
    {
        Console.Write($"Filtered file found: {item.Name}\n");
    };

    var list = fileSystemVisitor.GetAllItems().ToList();

}
catch (FileNotFoundException e)
{
    Console.WriteLine(e.Message);
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}


