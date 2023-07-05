using Aassur.Core.Data;

namespace Aassur.Resources.Components;

public class ContentButton : ContentView
{
    public event EventHandler Clicked;

    public ContentButton()
    {
        var tapGestureRecognizer = new TapGestureRecognizer();
        tapGestureRecognizer.Tapped += (_, _) => Clicked?.Invoke(this, EventArgs.Empty);
        GestureRecognizers.Add(tapGestureRecognizer);

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
                        Setters = { new Setter { Property = BackgroundColorProperty, Value = StaticVar.PrimaryColor } }
                    }
                }
            }
        });
    }
}