using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Mail;
using System;

namespace DatabaseConsole.Models.Entity;


[Index(nameof(Email), IsUnique = true)]
public class CustomerEntity
{
    public int Id { get; set; }

    [Column(TypeName = "nvarchar(30)")]
    public string FirstName { get; set; } = string.Empty;

    [Column(TypeName = "nvarchar(30)")]
    public string LastName { get; set; } = string.Empty;

    [Column(TypeName = "nvarchar(100)")]
    public string Email { get; set; } = string.Empty;

    [Column(TypeName = "char(13)")]
    public string PhoneNumber { get; set; } = string.Empty;

    public ErrandEntity Errand { get; set; } = null!;
}