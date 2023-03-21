namespace DatabaseConsole.Models;
using System;
public class Errand
{
    public int ErrandId { get; set; }
    public string ErrandDescription { get; set; } = null!;
    public DateTime TimeStamp { get; set; }

    public int CustomerId { get; set; }
    public Customer Customer { get; set; } = null!;
}