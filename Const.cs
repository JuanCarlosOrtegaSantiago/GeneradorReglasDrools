using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneradorReglasDrools
{
    internal class Const
    {
        public static List<string> parametros => new List<string>{"@fecha","@dias_a_procesar","@esquema","@esquema_trabajo",
            "@rango_a_considerar","@fecha_ini","@fecha_fin","@dias_historia" };

        public static List<string> DML => new List<string>{ "REFRESH","INSERT","UPDATE","DELETE" };

        public static List<string> DDL => new List<string>{ "CREATE" ,"DROP" ,"ALTER" ,"TRUNCATE" };

        public static List<string> SELECT => new List<string> { "COMPUTE" };

    }
}
