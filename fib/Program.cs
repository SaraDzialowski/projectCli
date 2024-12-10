using System.CommandLine;
var bundleOption = new Option<FileInfo>("--output", "File path and name");

var bundleCommand = new Command("bundle", "bundle code files to a single file");
bundleCommand.AddOption(bundleOption);
bundleCommand.SetHandler((FileInfo output) =>
{
    try
    {
        using (File.Create(output.FullName)) { }
        Console.WriteLine("file was created");
    }
    catch (DirectoryNotFoundException ex)
    {
        Console.WriteLine("file path is invalid");
    }
}, bundleOption);

var rootCommand = new RootCommand("Root command for File bundler CLI");
rootCommand.AddCommand(bundleCommand);
await rootCommand.InvokeAsync(args);

































