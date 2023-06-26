using System.Reflection;

namespace Aassur;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        CreateSqliteDbIfNotExist();

        MainPage = new AppShell();
    }

    private static void CreateSqliteDbIfNotExist()
    {
        const string resourceName = "Aassur.Core.DataBase.Aassur.db";
        var assembly = Assembly.GetExecutingAssembly();
        var destinationFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Aassur", "Aassur.db");

        using var stream = assembly.GetManifestResourceStream(resourceName);
        if (stream is null) throw new InvalidOperationException("Could not find embedded resource");

        using var fileStream = File.Create(destinationFile);
        stream.CopyTo(fileStream);
    }
}