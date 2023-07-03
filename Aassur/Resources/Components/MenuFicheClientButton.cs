namespace Aassur.Resources.Components;

public class MenuFicheClientButton : Button
{
    public MenuFicheClientButton()
    {
        var primaryColor = Color.FromRgb(55, 190, 189);
        var tertiaryColor = Color.FromRgb(58, 71, 70);
        
        if (Application.Current is not null && Application.Current.Resources.TryGetValue("Primary", out var obj) && obj is Color color)
        {
            primaryColor = color;
        }
        
        if (Application.Current is not null && Application.Current.Resources.TryGetValue("Tertiary", out var obj2) && obj2 is Color color2)
        {
            tertiaryColor = color2;
        }
        
        VisualStateManager.SetVisualStateGroups(this, new VisualStateGroupList
        {
            new()
            {
                Name = "CommonStates",
                States =
                {
                    new VisualState 
                    { 
                        Name = "Normal",
                        Setters =
                        {
                            new Setter { Property = BackgroundColorProperty, Value = tertiaryColor }
                        }
                    },
                    new VisualState 
                    { 
                        Name = "PointerOver",
                        Setters = 
                        { 
                            new Setter { Property = BackgroundColorProperty, Value = primaryColor },
                            new Setter { Property = TextColorProperty, Value = tertiaryColor } 
                        }
                    }
                }
            }
        });
    }
}