using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SixDegreesEntidades
{
    public class Usuarios
    {
        [Key]
        public int usuId { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }

        public string error { get; set; }
    }
}
