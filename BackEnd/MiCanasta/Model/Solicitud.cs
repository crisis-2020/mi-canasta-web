using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MiCanasta.MiCanasta.Model
{
    public class Solicitud
    {
        [Required]
        public int FamiliaId { get; set; }
        public Familia Familia { get; set; }
        [Required]
        public string Dni { get; set; }
        public Usuario Usuario { get; set; }

    }
}
