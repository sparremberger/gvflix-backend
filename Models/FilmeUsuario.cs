using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FirstEF.Models
{
    public class FilmeUsuario
    {
        public int filmeID { get; set; }

        public int usuarioID { get; set; }

        [Required]
        [StringLength(255)]
        public DateTime data_assistido { get; set; }

        public byte Nota { get; set; }
        public FilmeUsuario() { }
    }
}
