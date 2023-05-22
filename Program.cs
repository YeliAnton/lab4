using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        if (args.Length != 2)
        {
            Console.WriteLine("Usage: program.exe <directoryPath> <targetSubdirectoryName>");
            Console.WriteLine("Example: program.exe \"C:\\MyDirectory\" \"Subdirectory1\"");
            return;
        }

        string directoryPath = args[0];
        string targetSubdirectoryName = args[1];

        if (!Directory.Exists(directoryPath))
        {
            Console.WriteLine("The specified directory does not exist.");
            return;
        }

        try
        {
            string[] subdirectories = Directory.GetDirectories(directoryPath, targetSubdirectoryName, SearchOption.AllDirectories);

            if (subdirectories.Length == 0)
            {
                Console.WriteLine("No subdirectory with the specified name was found.");
                return;
            }

            Console.WriteLine("Found subdirectory(s):");
            foreach (string subdirectory in subdirectories)
            {
                Console.WriteLine(subdirectory);
            }
        }
        catch (UnauthorizedAccessException ex)
        {
            Console.WriteLine($"Access to the directory '{ex.Message.Replace("Access to the path", "").Trim()}' is denied.");
        }
    }
}
