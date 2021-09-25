using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiManejoErrores.Services
{
    [Serializable]
    public class Error
    {
        public string codigo { get; set; }
        public string descripcion { get; set; }
        public int httpstatuscode { get; set; }


    }
}
