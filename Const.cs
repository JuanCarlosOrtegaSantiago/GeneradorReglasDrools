using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneradorReglasDrools
{
    internal class Const
    {
        public static List<string> parametros => new List<string>{"@fecha",
"@dias_a_procesar",
"@esquema",
"@esquema_trabajo",
"@rango_a_considerar",
"@fecha_ini",
"@fecha_fin" };

        public string TypeDBLocal => "Local";

    }
}
