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
            "@rango_a_considerar","@fecha_ini","@fecha_fin","@dias_historia", "@date", "@date_init", "@date_final", "@week",
            "@week_init", "@month_init", "@month_final", "@yearWeek", "@year_init", "@year_final" };
        public static List<string> parametrosFecha => new List<string> { "@fecha", "@date", "@date_init", "@date_final", 
            "@fecha_ini","@fecha_fin", "@yearWeek"};

        public static List<string> DML => new List<string> { "REFRESH", "INSERT", "UPDATE", "DELETE" };

        public static List<string> DDL => new List<string> { "CREATE", "DROP", "ALTER", "TRUNCATE" };

        public static List<string> SELECT => new List<string> { "COMPUTE", "SELECT" };

        public static string[] endParam => new string[] { " ", ".", ")", ",", "'", "-", ";" };
    }
}
