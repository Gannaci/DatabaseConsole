using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static DatabaseConsole.Models.Entity.CustomerEntity;
using System;

namespace DatabaseConsole.Models.Entity
{
    public class StatusEntity
    {
        [Key]
        public int StatusId { get; set; }

        [Column(TypeName = "nvarchar(max)")]
        public Status Status { get; set; }
        [Column(TypeName = "nvarchar(max)")]
        public string Comment { get; set; } = string.Empty;
        public DateTime UpdateTime { get; set; }

        public int ErrandId { get; set; }
        public ErrandEntity Errand { get; set; } = null!;
    }

    public enum Status
    {
        [Display(Name = "Ej Pågående")]
        NotStarted,
        [Display(Name = "Pågående")]
        Started,
        [Display(Name = "Klar")]
        Done
    }
}
