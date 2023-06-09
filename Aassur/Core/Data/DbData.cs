﻿using Aassur.Core.Model;
using Aassur.Core.Services;

namespace Aassur.Core.Data;

public class DbData
{
    #region Statements

    public IEnumerable<Client> Clients { get; private set; } = new List<Client>();
    public IEnumerable<Address> Address { get; private set; } = new List<Address>();
    public IEnumerable<ListCivility> ListCivility { get; private set; } = new List<ListCivility>();
    public IEnumerable<ListCity> ListCity { get; private set; } = new List<ListCity>();
    public IEnumerable<ListFamilyStatus> ListFamilyStatus { get; private set; } = new List<ListFamilyStatus>();
    public IEnumerable<ListNews> ListNews { get; private set; } = new List<ListNews>();

    public DbData()
    {
        Task.Run(SetDbDatas);
    }

    #endregion
    
    public async Task RefreshDataAsync()
    {
        await Task.Run(SetDbDatas);
    }
    
    private async Task SetDbDatas()
    {
        Clients = await SqliteService.Client.GetAllAsync();
        Address = await SqliteService.Address.GetAllAsync();
        ListCivility = await SqliteService.ListCivility.GetAllAsync();
        ListCity = await SqliteService.ListCity.GetAllAsync();
        ListFamilyStatus = await SqliteService.ListFamilyStatus.GetAllAsync();
        ListNews = await SqliteService.ListNews.GetAllAsync();
    }
    
    public static bool ShouldDelay()
    {
        return !App.DbData.Clients.Any() 
               && !App.DbData.Address.Any() 
               && !App.DbData.ListCivility.Any() 
               && !App.DbData.ListCity.Any()
               && !App.DbData.ListFamilyStatus.Any()
               && !App.DbData.ListNews.Any();
    }
}