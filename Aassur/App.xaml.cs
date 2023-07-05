using Aassur.Core.Data;
using Aassur.Core.DataBase;

namespace Aassur;

public partial class App
{
    #region Statements

    public static DbData DbData { get; } = new();
    
    public App()
    {
        DatabaseInitializer.CreateSqliteDbIfNotExist();
        InitializeComponent();
        MainPage = new AppShell();
    }

    #endregion

    #region Functions

    protected override Window CreateWindow(IActivationState activationState)
    {
        var window = base.CreateWindow(activationState);

        const int newWidth = 1200;
        const int newHeight = 800;
        
        window.Width = newWidth;
        window.MinimumWidth = newWidth;
        window.Height = newHeight;
        window.MinimumHeight = newHeight;

        return window;
    }
    
    public static void ChangeMainPage(Page page)
    {
        if (Current is not null) 
            Current.MainPage = page;
    }

    #endregion
}