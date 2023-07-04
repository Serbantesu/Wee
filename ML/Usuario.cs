using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Usuario
    {        
        public int IdUsuario { get; set; }
        
        public string Nombre { get; set; }
        
        public string Correo { get; set; }
        
        public byte[] Password { get; set; }
        
        [StringLength(10)]        
        public string Numero { get; set; }
        
        public string Empresa { get; set; }
    }
}
