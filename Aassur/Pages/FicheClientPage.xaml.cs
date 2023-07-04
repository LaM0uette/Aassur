using Aassur.Core.Model;
using Aassur.View;

namespace Aassur.Pages;

public partial class FicheClientPage : ContentPage
{
    #region Statements

    public FicheClientPage(Client client)
    {
        InitializeComponent();
        
        frame.Content = new TestView();
    }

    #endregion
}