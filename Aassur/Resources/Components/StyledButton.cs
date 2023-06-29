﻿namespace Aassur.Resources.Components;

public class StyledButton : Button
{
    public StyledButton()
    {
        var primaryColor = Color.FromRgb(255, 0, 0);
        if (Application.Current is not null && Application.Current.Resources.TryGetValue("Primary", out var obj) && obj is Color color)
        {
            primaryColor = color;
        }
        
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
                        Setters = { new Setter { Property = BackgroundColorProperty, Value = primaryColor } }
                    }
                }
            }
        });
    }
}