using System;
using System.Collections.Generic;

namespace ToDoApp.Server.Models;

public partial class Person
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Message { get; set; }

    public DateOnly? Date { get; set; }
}
