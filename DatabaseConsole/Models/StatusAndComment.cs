using DatabaseConsole.Models.Entity;
using System.ComponentModel.DataAnnotations;
using System;

namespace DatabaseConsole.Models;

public class StatusAndComment
{
    public int StatusId { get; set; }
    public Status Status { get; set; }
    public string Comment { get; set; } = string.Empty;
    public DateTime UpdateTime { get; set; }
    public int ErrandId { get; set; }
    public Errand Errand { get; set; } = null!;
}

