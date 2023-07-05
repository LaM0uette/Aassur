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
    }

    #endregion

    private void ButtonTabControl_OnClicked(object sender, EventArgs e)
    {
        var primaryColor = Color.FromRgb(55, 190, 189);
        var tertiaryColor = Color.FromRgb(58, 71, 70);
        
        ButtonTabControl0.BackgroundColor = tertiaryColor;
        ButtonTabControl1.BackgroundColor = tertiaryColor;
        ButtonTabControl2.BackgroundColor = tertiaryColor;

        if (sender is Button button)
            button.BackgroundColor = primaryColor;
    }
}