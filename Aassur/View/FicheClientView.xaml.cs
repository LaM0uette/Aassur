using Aassur.Core.Model;

namespace Aassur.View;

public partial class FicheClientView
{
    #region Statements

    public FicheClientView(Client client)
    {
        InitializeComponent();
        
        frame.Content = new TestView();
    }

    #endregion
}