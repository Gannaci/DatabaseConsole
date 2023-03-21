using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
using System;

namespace DatabaseConsole.Models.Entity;


    public class ErrandEntity
    {
        [Key]
        public int ErrandId { get; set; }


        [Column(TypeName = "nvarchar(max)")]
        public string ErrandDescription { get; set; } = string.Empty;

        public DateTime TimeStamp { get; set; }

    
        public int CustomerId { get; set; }
        public CustomerEntity Customer { get; set; } = null!;

        public StatusEntity StatusAndComment { get; set; } = null!;

}
