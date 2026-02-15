using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Welcome.Model;

namespace DataLayer.Model
{
    internal class DatabaseUser : User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override int Id { get => base.Id; set => base.Id = value; }

        public DatabaseUser() : base()
        {
        }
    }
}
