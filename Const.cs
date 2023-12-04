using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GeneradorReglasDrools
{
    internal class Const
    {
        static IConfiguration config;
        static Const()
        {
            try
            {
                config = new ConfigurationBuilder()
               .SetBasePath(AppContext.BaseDirectory + "/prop")
               .AddJsonFile(nameFile, optional: false, reloadOnChange: true)
               .Build();
            }
            catch (Exception)
            {
                Console.WriteLine(string.Format("\nNo se puso encontrar el archivo de propiedades -> {0}prop\\{1}", AppContext.BaseDirectory,nameFile));
                return;
            }
        }
        public static List<string> parametros => GetParamLst("Parametros");

        public static string nameFile => "appsettings.json";

        /*new List<string>{"@fecha","@dias_a_procesar","@esquema","@esquema_trabajo",
   "@rango_a_considerar","@fecha_ini","@fecha_fin","@dias_historia", "@date", "@date_init", "@date_final", "@week",
   "@week_init", "@month_init", "@month_final", "@yearWeek", "@year_init", "@year_final" };*/
        public static List<string> parametrosFecha => GetParamLst("ParametrosFecha");
        /*new List<string> { "@fecha", "@date", "@date_init", "@date_final", 
            "@fecha_ini","@fecha_fin", "@yearWeek"};*/

        public static List<string> DML => GetParamLst("DML");
            /*new List<string> { "REFRESH", "INSERT", "UPDATE", "DELETE" };*/

        public static List<string> DDL => GetParamLst("DDL"); 
        /*new List<string> { "CREATE", "DROP", "ALTER", "TRUNCATE" };*/

        public static List<string> SELECT => GetParamLst("SELECT"); 
        /*new List<string> { "COMPUTE", "SELECT" };*/

        public static string[] endParam => GetParamLst("EndParam").ToArray(); 
        /*new string[] { " ", ".", ")", ",", "'", "-", ";" };*/


        private static List<string> GetParamLst(string key)
        {
                List<string> listaDeNombres = new List<string>();
            try
            {
                var subSections = config.GetSection(key).GetChildren();

                foreach (var subSection in subSections)
                    listaDeNombres.Add(subSection.Value);

                return listaDeNombres;
            }
            catch (Exception ex)
            {
                return listaDeNombres;
            }
        }

    }



}



/*
 * 
 * /*
    string connectionString = ConfigurationManager.AppSettings["DatabaseConnectionString"];
    Console.WriteLine($"Database Connection String: {connectionString}");
    
IConfiguration config = new ConfigurationBuilder()
    .SetBasePath(AppContext.BaseDirectory)
    .AddJsonFile("appsettings.json", optional: false)
    .Build();


string LoggJuan = config.GetSection("Logging")["Juan"];
string Juan = config.GetConnectionString("Juan");

string connectionString = config.GetConnectionString("Database");
string connectionStr = config.GetConnectionString("e");
string connectitr = config.GetConnectionString("f");

IEnumerable<KeyValuePair<string, string?>> mm = config.AsEnumerable();


foreach (KeyValuePair<string, string> item in mm)
{
    if (item.Key.Equals("Juan"))
        Console.WriteLine(item);
    else if (item.Key.Equals("Logging:Juan"))
        Console.WriteLine(item);
    else
        Console.WriteLine(item);
}

Console.WriteLine($"Database Connection String: {connectionString}");


Console.ReadKey();
* 
 * */