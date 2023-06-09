﻿using Aassur.Core.Services.Repository;
using SQLite;

namespace Aassur.Core.Model;

public class ListTypeClient : IIdentifiable
{
    [PrimaryKey, AutoIncrement, Indexed] public int Id { get; set; }
    public string Name { get; set; }
}