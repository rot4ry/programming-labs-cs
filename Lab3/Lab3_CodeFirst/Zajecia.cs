using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Lab3
{
    public class Zajecia
    {
        public int Id { get; set; }
        [Required]                          //adnotacje - kontrola inputu do bazy
        [MaxLength(255)]
        public string Nazwa { get; set; }
        public DateTime GodzinaRozpoczecia { get; set; }
    }
}
