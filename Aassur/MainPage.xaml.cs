﻿using Aassur.Core.Factory;

namespace Aassur;

public partial class MainPage
{
    #region Statements

    public MainPage()
    {
        InitializeComponent();
        
        Task.Run(Test);
    }

    #endregion
    
    #region Functions

    private async void Test()
    {
        while (!App.DbData.Clients.Any() && !App.DbData.ListCivility.Any() && !App.DbData.ListCity.Any())
        {
            await Task.Delay(100);
        }
        
        var clientsList = App.DbData.Clients
            .OrderByDescending(client => client.LastModificationDate)
            .Take(3)
            .ToList();

        foreach(var client in clientsList)
        {
            StackLayoutRecentClients.Children.Add(ClientElementsFactory.CreateClientElements(client));
        }
    }

    #endregion
}