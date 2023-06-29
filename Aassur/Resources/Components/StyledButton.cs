namespace Aassur.Resources.Components;

public class StyledButton : Button
{
    public StyledButton()
    {
        VisualStateManager.SetVisualStateGroups(this, new VisualStateGroupList
        {
            new()
            {
                Name = "CommonStates",
                States =
                {
                    new VisualState { Name = "Normal" },
                    new VisualState 
                    { 
                        Name = "PointerOver",
                        Setters = { new Setter { Property = BackgroundColorProperty, Value = Color.FromRgb(255, 0, 0) } }
                    }
                }
            }
        });
    }
}