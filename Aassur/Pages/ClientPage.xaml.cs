using Aassur.Core.Data;
using Aassur.Core.Model;
using Aassur.Core.Services;
using Aassur.View;

namespace Aassur.Pages;

public partial class ClientPage
{
    #region Statements

    private readonly Client _client;
    
    public ClientPage(Client client)
    {
        _client = client;
        
        InitializeComponent();
        InitializeView();
    }

    #endregion

    #region Events
    
    private void ButtonReturn_OnClicked(object sender, EventArgs e)
    {
        ReturnToMenuPage();
    }

    private void ButtonTabControl0_OnClicked(object sender, EventArgs e)
    {
        SetButtonTabControlBackground(sender);
        ChangeFrameView(new FicheClientView(_client));
    }
    
    private void ButtonTabControl1_OnClicked(object sender, EventArgs e)
    {
        SetButtonTabControlBackground(sender);
        ChangeFrameView(new FicheClientView(_client));
        
    }
    
    private void ButtonTabControl2_OnClicked(object sender, EventArgs e)
    {
        SetButtonTabControlBackground(sender);
        ChangeFrameView(new FicheClientView(_client));
        
    }
    
    private void ButtonIconEdit_OnClicked(object sender, EventArgs e)
    {
    }
    
    private async void ButtonIconDelete_OnClicked(object sender, EventArgs e)
    {
        await SqliteService.Client.DeleteAsync(_client.Id);
        await App.DbData.RefreshDataAsync();
        
        ReturnToMenuPage();
    }
    
    private void ButtonIconMap_OnClicked(object sender, EventArgs e)
    {
    }
    
    #endregion

    #region Functions
    
    private static void ReturnToMenuPage()
    {
        App.ChangeMainPage(new MenuPage());
    }
    
    private void InitializeView()
    {
        ChangeFrameView(new FicheClientView(_client));
        ButtonTabControl0.BackgroundColor = StaticVar.PrimaryColor;
    }

    private void ChangeFrameView(Microsoft.Maui.Controls.View view)
    {
        FrameView.Content = view;
    }

    private void SetButtonTabControlBackground(object sender)
    {
        ResetBackgroundButtons();

        if (sender is Button button) 
            button.BackgroundColor = StaticVar.PrimaryColor;
    }
    
    private void ResetBackgroundButtons()
    {
        ButtonTabControl0.BackgroundColor = StaticVar.TertiaryColor;
        ButtonTabControl1.BackgroundColor = StaticVar.TertiaryColor;
        ButtonTabControl2.BackgroundColor = StaticVar.TertiaryColor;
    }

    #endregion
}