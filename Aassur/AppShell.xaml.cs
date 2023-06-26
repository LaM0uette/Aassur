namespace Aassur;

public partial class AppShell
{
    public AppShell()
    {
        InitializeComponent();

        Items.Add(DeviceInfo.Current.Idiom.Equals(DeviceIdiom.Phone) 
            ? new ShellContent {Content = new MainPageMobile()} 
            : new ShellContent {Content = new MainPage()});
    }
}