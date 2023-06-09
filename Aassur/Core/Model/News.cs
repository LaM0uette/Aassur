﻿using Aassur.Core.Services.Repository;
using SQLite;

namespace Aassur.Core.Model;

public class News : IIdentifiable
{
    [PrimaryKey, AutoIncrement, Indexed] public int Id { get; set; }
    [Indexed] public int NewsId { get; set; }
    public string Date { get; set; }
    public string Note { get; set; }
}