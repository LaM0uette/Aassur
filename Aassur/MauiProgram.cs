using Aassur.Core.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Aassur;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var sqliteDbPath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Core", "DataBase", "dataBase.db");
        
        var builder = MauiApp.CreateBuilder();
        
        builder.Services.AddDbContext<SqliteDbContext>(options =>
            options.UseSqlite($"Data Source={sqliteDbPath}"));
        
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}