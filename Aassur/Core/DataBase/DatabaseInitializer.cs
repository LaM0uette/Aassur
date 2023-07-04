using System.Reflection;

namespace Aassur.Core.DataBase;

public class DatabaseInitializer
{
    private const string _resourceName = "Aassur.Core.DataBase.Aassur.db";
    private const string _destinationDirectoryName = "Aassur";
    private const string _destinationFileName = "Aassur.db";

    public static void CreateSqliteDbIfNotExist()
    {
        var assembly = Assembly.GetExecutingAssembly();
        var destinationDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), _destinationDirectoryName);

        CreateDirectory(destinationDirectory);

        var destinationFile = Path.Combine(destinationDirectory, _destinationFileName);

        if (FileExists(destinationFile)) 
            return;

        using var stream = GetEmbeddedResourceStream(assembly, _resourceName);
        CreateFileFromStream(destinationFile, stream);
    }

    private static void CreateDirectory(string directory)
    {
        Directory.CreateDirectory(directory);
    }

    private static bool FileExists(string file)
    {
        return File.Exists(file);
    }

    private static Stream GetEmbeddedResourceStream(Assembly assembly, string resourceName)
    {
        var stream = assembly.GetManifestResourceStream(resourceName);
        if (stream == null) throw new InvalidOperationException("Could not find embedded resource");

        return stream;
    }

    private static void CreateFileFromStream(string destinationFile, Stream stream)
    {
        using var fileStream = File.Create(destinationFile);
        stream.CopyTo(fileStream);
    }
}