using System;
using System.Collections.Generic;
using System.Text;

using SQLite;

namespace CarritoCompras.Modelo
{
    public class PersonModel
    {
        [PrimaryKey, AutoIncrement]
        public Guid PersonId { get; set; }

        [MaxLength(30)]
        public string NameField { get; set; }

        [MaxLength(2)]
        public int AgeField { get; set; }
    }
}
