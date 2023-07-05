using Aassur.Core.Data;

namespace Aassur.Resources.Components;

public class MenuFicheClientButton : Button
{
    public MenuFicheClientButton()
    {
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
                            new Setter { Property = BackgroundColorProperty, Value = StaticVar.TertiaryColor }
                        }
                    },
                    new VisualState 
                    { 
                        Name = "PointerOver",
                        Setters = 
                        { 
                            new Setter { Property = BackgroundColorProperty, Value = StaticVar.PrimaryColor },
                            new Setter { Property = TextColorProperty, Value = StaticVar.TertiaryColor } 
                        }
                    }
                }
            }
        });
    }
}