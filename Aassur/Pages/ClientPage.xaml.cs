using Aassur.Core.Data;
using Aassur.Core.Model;
using Aassur.Core.Services;
using Aassur.View;

namespace Aassur.Pages;

public partial class ClientPage
{
    #region Statements

    private Client _client;
    
    public ClientPage(Client client)
    {
        _client = client;
        
        InitializeComponent();
        InitializeView();
        InitializeClient();
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
        SetButtonEditVisibility(true);
    }

    private async void ButtonIconDelete_OnClicked(object sender, EventArgs e)
    {
        var result = await DisplayAlert("Confirmation", $"Êtes-vous sûr de vouloir supprimer le client {_client.FullName} de la base ?", "Supprimer", "Annuler");
        
        if(!result) return;
        
        await SqliteService.Client.DeleteAsync(_client.Id);
        await App.DbData.RefreshDataAsync();
        
        ReturnToMenuPage();
    }
    
    private void ButtonIconMap_OnClicked(object sender, EventArgs e)
    {
    }
    
    private async void ButtonEditOk_OnClicked(object sender, EventArgs e)
    {
        var result = await DisplayAlert("Confirmation", "Enregistrer les modifications ?", "Valider", "Annuler");
        
        if(!result) return;
        
        SetButtonEditVisibility(false);
    }
    
    private async void ButtonEditCancel_OnClicked(object sender, EventArgs e)
    {
        var result = await DisplayAlert("Confirmation", "Annuler les modifications ?", "Annuler", "Retour");
        
        if(!result) return;
        
        SetButtonEditVisibility(false);
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
    
    private void InitializeClient()
    {
        FilteredEntrySimply.SetPickerSearchSelection(_client.FullName);
        FilteredEntrySimply.PickerIndexChanged += OnPickerIndexChanged;
    }

    private void OnPickerIndexChanged(object sender, EventArgs e)
    {
        _client = FilteredEntrySimply.Client;
        ChangeFrameView(new FicheClientView(_client));
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
    
    private void SetButtonEditVisibility(bool visibility)
    {
        ButtonEditOk.IsVisible = visibility;
        ButtonEditCancel.IsVisible = visibility;
    }

    #endregion
}