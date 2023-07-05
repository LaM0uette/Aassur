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
}