using Aassur.Core.Data;
using Aassur.Core.Model;
using Aassur.View;

namespace Aassur.Pages;

public partial class ClientPage
{
    #region Statements

    public ClientPage(Client client)
    {
        InitializeComponent();
        InitializeView();
    }

    #endregion

    #region Events
    
    private void ButtonReturn_OnClicked(object sender, EventArgs e)
    {
        App.ChangeMainPage(new MenuPage());
    }

    private void ButtonTabControl_OnClicked(object sender, EventArgs e)
    {
        ResetBackgroundButtons();

        if (sender is Button button) 
            button.BackgroundColor = StaticVar.PrimaryColor;
    }

    #endregion

    #region Functions
    
    private void InitializeView()
    {
        ChangeFrameView(new TestView());
        ButtonTabControl0.BackgroundColor = StaticVar.PrimaryColor;
    }

    private void ChangeFrameView(Microsoft.Maui.Controls.View view)
    {
        FrameView.Content = view;
    }

    private void ResetBackgroundButtons()
    {
        ButtonTabControl0.BackgroundColor = StaticVar.TertiaryColor;
        ButtonTabControl1.BackgroundColor = StaticVar.TertiaryColor;
        ButtonTabControl2.BackgroundColor = StaticVar.TertiaryColor;
    }

    #endregion
}