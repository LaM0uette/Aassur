﻿using Aassur.View;

namespace Aassur;

public partial class AppShell
{
    public AppShell()
    {
        InitializeComponent();
            
        // Items.Add(DeviceInfo.Current.Idiom.Equals(DeviceIdiom.Phone) 
        //     ? new ShellContent {Content = new MainPageMobile()} 
        //     : new ShellContent {Content = new MenuPage()});
        
        // TODO: Remove this after finishing the mobile version
        Items.Add(new ShellContent {Content = new MainView()});
    }
}