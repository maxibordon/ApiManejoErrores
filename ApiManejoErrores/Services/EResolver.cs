using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ApiManejoErrores.Services
 {  
    public class ECode
    {        
        public string code { get; set; }
        public string analyticsCode { get; set;}
    }
    public static class EResolver
    {
        
        private static Error GetError(string codigo)
        {
            StreamReader r = new StreamReader(@"Services/errores.json");
            string _json = r.ReadToEnd();

            JObject json = JObject.Parse(_json);
            Error error = null;
            IEnumerable<JToken> items = json.SelectTokens(string.Format("$.Errores[?(@.codigo == '{0}')]", codigo));
            if (items.Count() > 0)
            {
               JToken elemento = items.ToList()[0];
               error = elemento.ToObject<Error>();
           }
            return error;
        }
        public static Error GetStatusCode(ECode codigo)
        {
            Error error = null;
            if (codigo.code=="200")
            {
                error = new Error();
                error.httpstatuscode = 200;
                error.descripcion = "Ejecucion exitosa";
            }
            else
            {
                error = GetError(codigo.analyticsCode);
            }
            return error;
        }      

    }
}
