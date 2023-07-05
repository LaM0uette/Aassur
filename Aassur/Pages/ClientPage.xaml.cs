using Aassur.Core.Data;
using Aassur.Core.Model;
using Aassur.View;

namespace Aassur.Pages;

public partial class ClientPage : ContentPage
{
    #region Statements

    public ClientPage(Client client)
    {
        InitializeComponent();
        
        FrameView.Content = new TestView();
        
        ButtonTabControl0.BackgroundColor = StaticVar.PrimaryColor;
    }

    #endregion

    private void ButtonTabControl_OnClicked(object sender, EventArgs e)
    {
        ButtonTabControl0.BackgroundColor = StaticVar.TertiaryColor;
        ButtonTabControl1.BackgroundColor = StaticVar.TertiaryColor;
        ButtonTabControl2.BackgroundColor = StaticVar.TertiaryColor;

        if (sender is Button button)
            button.BackgroundColor = StaticVar.PrimaryColor;
    }
}