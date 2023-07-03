using System.Reflection;
using Aassur.Core.Model;
using Aassur.Core.Services;

namespace Aassur;

public partial class App
{
    public static IEnumerable<Client> Clients { get; set; } = new List<Client>();
    
    public App()
    {
        CreateSqliteDbIfNotExist();
        
        InitializeComponent();
        
        Task.Run(AddAllClients);
        
        MainPage = new AppShell();
    }

    private static void CreateSqliteDbIfNotExist()
    {
        const string resourceName = "Aassur.Core.DataBase.Aassur.db";
        var assembly = Assembly.GetExecutingAssembly();
        
        var destinationDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Aassur");
        Directory.CreateDirectory(destinationDirectory);
        var destinationFile = Path.Combine(destinationDirectory, "Aassur.db");

        using var stream = assembly.GetManifestResourceStream(resourceName);
        if (stream is null) throw new InvalidOperationException("Could not find embedded resource");

        if (File.Exists(destinationFile)) return;
        using var fileStream = File.Create(destinationFile);
        stream.CopyTo(fileStream);
    }
    
    private async void AddAllClients()
    {
        var clients = await GetAllClientsAsync();
        Clients = clients;
    }
    
    private static async Task<IEnumerable<Client>> GetAllClientsAsync()
    {
        return await SqliteService.Client.GetAllAsync();
    }
}