using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversitySystem.Entities
{
     public class Curso
    {

        public int Id { get; set; }

        public int IdProfesor { get; set; }

        public String Sigla { get; set; }

        public String Nombre { get; set; }

        public int CupoMax { get; set; }

    }
}
