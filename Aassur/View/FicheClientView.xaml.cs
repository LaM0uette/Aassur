using Aassur.Core.Factory;
using Aassur.Core.Model;

namespace Aassur.View;

public partial class FicheClientView
{
    private static readonly List<string> TITLES_COORD = new()
    {
        "Adresse",
        "Code postal",
        "Ville",
        "Mobile",
        "Fixe",
        "Mail"
    };
    
    private static readonly List<string> TITLES_PROFIL = new()
    {
        "Pays de résidence",
        "Date de naissance",
        "Statut familial",
        "Fonction",
        "Foyer",
        "Loisirs",
        "Client(s) lié(s)",
        "Date de création",
        "Origine de création",
        "Date de dernier contact"
    };
    
    public FicheClientView(Client client)
    {
        InitializeComponent();
        
        StackLayoutCoordonnees.Children.Add(FormFactory.CreateForm(client, TITLES_COORD));
        StackLayoutProfil.Children.Add(FormFactory.CreateForm(client, TITLES_PROFIL));
    }
}