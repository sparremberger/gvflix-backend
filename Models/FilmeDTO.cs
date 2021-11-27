﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FirstEF.Models
{
    public class FilmeDTO
    {
        public int ID { get; set; }
        public string Nome { get; set; }

        public int Ano { get; set; }

        public FilmeDTO() { }
    }
}