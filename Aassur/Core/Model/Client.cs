﻿using SQLite;

namespace Aassur.Core.Model;

public class Client
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    
    public int? CivilityId { get; set; }
    
    public string FirstName { get; set; }
    
    public string LastName { get; set; }
}
