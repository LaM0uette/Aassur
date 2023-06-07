using Aassur.Core.Data;
using Aassur.Core.Model;
using Aassur.Core.Services.Repository;
using Aassur.ViewModel;

namespace Aassur;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();
        
        var serviceCollection = new ServiceCollection();
        serviceCollection.AddDbContext<SqliteDbContext>();
        serviceCollection.AddDbContext<MySqlDbContext>();
        serviceCollection.AddScoped(typeof(IRepository<>), typeof(RepositorySQLite<>));
        serviceCollection.AddScoped(typeof(IRepository<>), typeof(RepositoryMySQL<>));
        ServiceProvider = serviceCollection.BuildServiceProvider();

        MainPage = new AppShell();
    }
    
    private static void ConfigureServices(IServiceCollection services)
    {
        services.AddSingleton<MainPageViewModel>();
        services.AddSingleton<IRepository<Client>, RepositorySQLite<Client>>();
    }
    
    public IServiceProvider ServiceProvider { get; private set; }
}