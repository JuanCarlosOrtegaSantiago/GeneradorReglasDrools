//constantes para reemplazar
using System.Text;

string reemplazarTipoEncabezado = "*tipoEncabezado";
string reemplazarSubStep = "*subStep";
string reemplazarStep = "*step";
string reemplazarFlujoDeRegla = "*flujoDeRegla";
string reemplazarTipoDeFlujoParaCondicion = "*tipoDeFlujoParaCondicion";

//constantes para realizar reemplazo
string reemplazoDeEsquemaEsquema_trabajo = "%s.";
string reemplazoDeDatoNormal = "%s";
string reemplazoDeFecha = "'%s'";

//parametros a buscar
string fecha = "@fecha";
string dias_a_procesar = "@dias_a_procesar";
string esquema = "@esquema.";
string esquema_trabajo = "@esquema_trabajo.";
string rango_a_considerar = "@rango_a_considerar";
string porcentaje = "%_";

//estructura para obtener datos para concatenar
string leerEsquema_de_trabajo = "$esquema_trabajo: get(\"params\").get(\"esquema_trabajo\"),\n";
string leerEsquema = "                           $esquema: get(\"params\").get(\"esquema\"),\n";
string leerFecha = "                           $fecha: get(\"params\").get(\"fecha\"),\n";
string leerDias_a_procesar = "                           $dias_a_procesar: get(\"params\").get(\"dias_a_procesar\"),\n";
string leerRango_a_considerar = "                           $rango_a_considerar: get(\"params\").get(\"rango_a_considerar\"),\n";

//constantes para concatenar al query
string concatenarEsquema_trabajo = "\n                $esquema_trabajo";
string concatenarEsquema = "\n                $esquema";
string concatenarFecha = "\n                $fecha";
string concatenarDias_a_procesar = "\n                $dias_a_procesar";
string concatenarRango_a_considerar = "\n                $rango_a_considerar";

//variables a ocupar
string consarroba = "@";
string concat = "";
string strucparaLeer = "";
int contfechas = 0;
int contdiasaprocesar = 0;
int contesquemas = 0;
int contesquemadeporcentajes = 0;


String FINALqueryConcatenado = "";


Console.WriteLine("Que deceas hacer?\n\t1 - Generar Reglas \n\t2 - Generar querys \n\t3 - Generar Reglas con querys por un archivo .txt");
string op=Console.ReadLine();

switch (op)
{
    case "1":
        generadorDeReglas();
        break;
    case "2":
        generadorDeQuerys();
        break;
    case "3":
        Prueba();
        break;

    default:

        break;
}

void Prueba()
{
    Console.Clear();

    Console.Write("Ingresa el nombre del archivo NOTA sin el  \".txt\":  ");
    string archivo = Console.ReadLine();
    string tipoEncabezado = archivo;
    tipoEncabezado = tipoEncabezado.ToUpper();
    archivo += ".txt";

    Console.Write("Ingresa la ruta: sonde se leera el .txt:  ");
    string ruta = Console.ReadLine();

    //Console.Clear();
    //Console.Write("Escribe el nombre para diferenciar encabezado de la regla:");
     //tipoEncabezado = Console.ReadLine();

    Console.Clear();
    Console.Write("Escribe el tipo de flujo para la diferenciar la regla ejemplo  :");
    string flujoDeRegla = Console.ReadLine();

    Console.Clear();
    Console.Write("Escribe el tipo de flujo para la condicion d ela regla \"Equipos o Interfaces\":");
    string tipoDeFlujoParaCondicion = Console.ReadLine();


    Console.Clear();


    string path = ruta.Replace(@"\\", @"\");
    path += @"\" + archivo;
    string fin = ruta + @"\" + flujoDeRegla + "_" + tipoEncabezado + ".txt";



    try
    {
    Console.Write("Leyendo archivo . . . .");
    Thread.Sleep(2500);
    Console.Clear();

        using (StreamWriter escri = File.CreateText(fin))
        {

            Console.Write("Creando archivo ");
            Thread.Sleep(1000);
            foreach (string line in System.IO.File.ReadLines(@path))
            {
                string[] Arreglo = GetSubStepsPorPartes(line);

                string salida = "";
                string queryfinal = "";
                concat = "";
                strucparaLeer = "";
                string queryConcatenado = "";
                //StringBuilder sb = new StringBuilder();
                string reglafin = "";

                if (!Arreglo[3].Contains(porcentaje))
                {
                    queryConcatenado = GetQueryStringFormat(Arreglo[3], salida, queryfinal);
                    reglafin = GetReglaFin(queryConcatenado.ToString(), concat);

                }
                else
                {
                    queryConcatenado = GetQueryNormal(Arreglo[3], salida, queryfinal);

                    reglafin = GetReglaFin(queryConcatenado.ToString(), null);
                }

                string regla = GerearRegla(flujoDeRegla, tipoEncabezado, tipoDeFlujoParaCondicion, Arreglo[0], Arreglo[1], Arreglo[2], reglafin, strucparaLeer);


                escri.WriteLine(regla + "\n");
                Console.Write(". ");
                Thread.Sleep(450);


            }
        }

        Console.Write("\n\nArchivo creado con exito . . .\n\r\r\tRUTA DEL ARCHIVO: " + fin);
        
        Thread.Sleep(5000);
    }
    catch (Exception ex)
    {
        Console.Clear();
        Console.Write("No se pudo leer/encontrar el archivo: \nMensaje:\t" + ex.Message);
        File.Delete(fin);
    }


}

string GetReglaFin(string queryConcatenado, string? concat)
{
    return concat == null? "                //Se Define Query\r\n                String Query = \"" + queryConcatenado + "\";" :
                           "                //Se Define Query\r\n                String Query = String.format(\"" + queryConcatenado + "\",\r                " + concat + ");";
}

string GetQueryNormal(string queryentrante, string salida, string queryfinal)
{
    if (queryentrante.Contains(consarroba))
    {
        int first = queryentrante.IndexOf(consarroba);
        string salidaj = queryentrante.Substring(first);
        string jj = salidaj.Substring(1);
        int fir2 = jj.IndexOf(consarroba);



        if (!jj.Contains(consarroba))
        {

            if (queryentrante.Contains(esquema_trabajo))
            {
                queryfinal = queryentrante.Replace(esquema_trabajo, "\"" + " + $esquema_trabajo + " + "\".");
                strucparaLeer+=strucparaLeer.Contains(leerEsquema_de_trabajo)? "": leerEsquema_de_trabajo;
            }
            if (queryentrante.Contains(esquema))
            {
                queryfinal = queryentrante.Replace(esquema, "\"" + " + $esquema + " + "\".");
                strucparaLeer += strucparaLeer.Contains(leerEsquema) ? "" : leerEsquema;
            }
            if (queryentrante.Contains(fecha))
            {
                queryfinal = queryentrante.Replace(fecha, "'\"" + " + $fecha + " + "\"'");
                strucparaLeer += strucparaLeer.Contains(leerFecha) ? "" : leerFecha;
            }
            if (queryentrante.Contains(dias_a_procesar))
            {
                queryfinal = queryentrante.Replace(dias_a_procesar, "\"" + " + $dias_a_procesar + " + "\"");
                strucparaLeer += strucparaLeer.Contains(leerDias_a_procesar) ? "" : leerDias_a_procesar;
                
            }
            if (queryentrante.Contains(rango_a_considerar))
            {
                queryfinal = queryentrante.Replace(rango_a_considerar, "\"" + " + $rango_a_considerar + " + "\"");
                strucparaLeer += strucparaLeer.Contains(leerRango_a_considerar) ? "" : leerRango_a_considerar;

            }

            return queryfinal;
        }
        string buscar = queryentrante.Substring(0, fir2 + first + 1);
        string restodequery = queryentrante.Substring(buscar.Length);

        if (buscar.Contains(esquema_trabajo))
        {
            queryfinal = buscar.Replace(esquema_trabajo, "\""+ " + $esquema_trabajo + " + "\".");
            strucparaLeer += strucparaLeer.Contains(leerEsquema_de_trabajo) ? "" : leerEsquema_de_trabajo;
            queryfinal += restodequery;
            return GetQueryNormal(queryfinal, salida, queryfinal);
        }
        if (buscar.Contains(esquema))
        {

            queryfinal = buscar.Replace(esquema, "\"" + " + $esquema + " + "\".");
            strucparaLeer += strucparaLeer.Contains(leerEsquema) ? "" : leerEsquema;
            queryfinal += restodequery;
            return GetQueryNormal(queryfinal, salida, queryfinal);
        }
        if (buscar.Contains(fecha))
        {

            queryfinal = buscar.Replace(fecha, "'\"" + " + $fecha + " + "\"'");
            strucparaLeer += strucparaLeer.Contains(leerFecha) ? "" : leerFecha;
            queryfinal += restodequery;
            return GetQueryNormal(queryfinal, salida, queryfinal);
        }
        if (buscar.Contains(dias_a_procesar))
        {
            queryfinal = buscar.Replace(dias_a_procesar, "\"" + " + $dias_a_procesar + " + "\"");
            strucparaLeer += strucparaLeer.Contains(leerDias_a_procesar) ? "" : leerDias_a_procesar;
            queryfinal += restodequery;
            return GetQueryNormal(queryfinal, salida, queryfinal);
        }
        if (buscar.Contains(rango_a_considerar))
        {
            queryfinal = queryentrante.Replace(rango_a_considerar, "\"" + " + $rango_a_considerar + " + "\"");
            strucparaLeer += strucparaLeer.Contains(leerRango_a_considerar) ? "" : leerRango_a_considerar;
            queryfinal += restodequery;
            return GetQueryNormal(queryfinal, salida, queryfinal);
        }

    }
    return queryfinal;

}

void generadorDeQuerys()
{
    foreach (string line in System.IO.File.ReadLines(@"c:\j\jj.txt"))
    {
        string salida = "";
        string queryfinal = "";
        concat = "";

        string queryConcatenado = GetQuery(line, salida, queryfinal);
        string regla = "                //Se Define Query\r\n                String Query = String.format(\"" + queryConcatenado + "\",\r                " + concat + ");";
    }
}
string GetQueryStringFormat(string queryentrante, string salida, string queryfinal)
    {
        if (queryentrante.Contains(consarroba))
        {
            int primerencuentro = queryentrante.IndexOf(consarroba);
            string query2aparte = queryentrante.Substring(primerencuentro);
            string jj = query2aparte.Substring(1);
            int fir2 = jj.IndexOf(consarroba);



            if (!jj.Contains(consarroba))
            {

                if (queryentrante.Contains(esquema_trabajo))
                {
                    queryfinal += queryentrante.Replace(esquema_trabajo, reemplazoDeEsquemaEsquema_trabajo);
                    concat += concatenarEsquema_trabajo;
                    strucparaLeer += strucparaLeer.Contains(leerEsquema_de_trabajo) ? "" : leerEsquema_de_trabajo;
                }
                if (queryentrante.Contains(esquema))
                {
                    queryfinal += queryentrante.Replace(esquema, reemplazoDeEsquemaEsquema_trabajo);
                    concat += concatenarEsquema;
                    strucparaLeer += strucparaLeer.Contains(leerEsquema) ? "" : leerEsquema;

                }
                if (queryentrante.Contains(fecha))
                {
                    queryfinal += queryentrante.Replace(fecha, reemplazoDeFecha);
                    concat += concatenarFecha;
                    strucparaLeer += strucparaLeer.Contains(leerFecha) ? "" : leerFecha;

                }
                if (queryentrante.Contains(dias_a_procesar))
                {
                    queryfinal += queryentrante.Replace(dias_a_procesar, reemplazoDeDatoNormal);
                    concat += concatenarDias_a_procesar;
                    strucparaLeer += strucparaLeer.Contains(leerDias_a_procesar) ? "" : leerDias_a_procesar;

                }
                if (queryentrante.Contains(rango_a_considerar))
                {
                    queryfinal += queryentrante.Replace(rango_a_considerar, reemplazoDeDatoNormal);
                    concat += concatenarRango_a_considerar;
                    strucparaLeer += strucparaLeer.Contains(leerRango_a_considerar) ? "" : leerRango_a_considerar;

                }

                return queryfinal;
            }
            string buscar = queryentrante.Substring(0, fir2 + primerencuentro + 1);

            if (buscar.Contains(esquema_trabajo))
            {
                queryfinal += buscar.Replace(esquema_trabajo, reemplazoDeEsquemaEsquema_trabajo);
                salida = queryentrante.Substring(buscar.Length);
                concat += concatenarEsquema_trabajo+",";
                strucparaLeer += strucparaLeer.Contains(leerEsquema_de_trabajo) ? "" : leerEsquema_de_trabajo;
                return GetQueryStringFormat(salida, salida, queryfinal);
            }
            if (buscar.Contains(esquema))
            {
                queryfinal += buscar.Replace(esquema, reemplazoDeEsquemaEsquema_trabajo);
                salida = queryentrante.Substring(buscar.Length);
                concat += concatenarEsquema+",";
                strucparaLeer += strucparaLeer.Contains(leerEsquema) ? "" : leerEsquema;

                return GetQueryStringFormat(salida, salida, queryfinal);
            }
            if (buscar.Contains(fecha))
            {
                queryfinal += buscar.Replace(fecha, reemplazoDeFecha);
                salida = queryentrante.Substring(buscar.Length);
                concat += concatenarFecha+",";
                strucparaLeer += strucparaLeer.Contains(leerFecha) ? "" : leerFecha;

                return GetQueryStringFormat(salida, salida, queryfinal);
            }
            if (buscar.Contains(dias_a_procesar))
            {
                queryfinal += buscar.Replace(dias_a_procesar, reemplazoDeDatoNormal);
                salida = queryentrante.Substring(buscar.Length);
                concat += concatenarDias_a_procesar+",";
                strucparaLeer += strucparaLeer.Contains(leerDias_a_procesar) ? "" : leerDias_a_procesar;
                return GetQueryStringFormat(salida, salida, queryfinal);
            }
            if (buscar.Contains(rango_a_considerar))
            {
                queryfinal += buscar.Replace(rango_a_considerar, reemplazoDeDatoNormal);
                salida = queryentrante.Substring(buscar.Length);
                concat += concatenarRango_a_considerar+",";
                strucparaLeer += strucparaLeer.Contains(leerRango_a_considerar) ? "" : leerRango_a_considerar;
                return GetQueryStringFormat(salida, salida, queryfinal);
            }

        }

    return queryfinal;

    }

    string GetQuery(string queryentrante, string salida, string queryfinal)
    {
        bool existefecha = queryentrante.Contains(fecha);
        bool existediasaprocesar = queryentrante.Contains(dias_a_procesar);
        bool existeesquema = queryentrante.Contains(esquema);
        bool existeEsquemadetrabajo = queryentrante.Contains(esquema_trabajo);


        bool existeprocentaje = queryentrante.Contains(porcentaje);

        if (!existeprocentaje)
        {


            //salida = queryentrante.Replace(esquema_trabajo, "%s");
            if (existeEsquemadetrabajo)
            {
                int first = queryentrante.IndexOf(esquema_trabajo) + esquema_trabajo.Length;
                salida = queryentrante.Substring(first);

                queryfinal += queryentrante.Substring(0, first);
                queryfinal = queryfinal.Replace(esquema_trabajo, "%s.");
                contesquemadeporcentajes += 1;
                return GetQuery(salida, salida, queryfinal);

            }

            if (existeesquema)
            {
                int first = queryentrante.IndexOf(esquema) + esquema.Length;
                salida = queryentrante.Substring(first);

                queryfinal += queryentrante.Substring(0, first);
                queryfinal = queryfinal.Replace(esquema, "%s.");
                contesquemas += 1;
                return GetQuery(salida, salida, queryfinal);
            }


            if (existefecha)
            {
                int first = queryentrante.IndexOf(fecha) + fecha.Length;
                salida = queryentrante.Substring(first);

                queryfinal += queryentrante.Substring(0, first);
                queryfinal = queryfinal.Replace(fecha, "'%s'");
                contfechas += 1;
                return GetQuery(salida, salida, queryfinal);
            }

            if (existediasaprocesar)
            {
                int first = queryentrante.IndexOf(dias_a_procesar) + dias_a_procesar.Length;
                salida = queryentrante.Substring(first);

                queryfinal += queryentrante.Substring(0, first);
                queryfinal = queryfinal.Replace(dias_a_procesar, "%s");
                contdiasaprocesar += 1;
                return GetQuery(salida, salida, queryfinal);
            }
        }



        if (existefecha || existeesquema || existeEsquemadetrabajo || existediasaprocesar)
        {
            return GetQuery(salida, salida, queryfinal);
        }
        else
        {
            if (salida.Length > 0)
            {
                queryfinal += salida;
            }
            return queryfinal;
        }


    }

    void generadorDeReglas()
    {



        string valorEnrada;
        do
        {

            Console.WriteLine("ingresa los Step y SubStep como se muestra en el siguiente ejemplo (Step-SubStep|SubStep): 1-1.1|1.2|1.3");
            valorEnrada = Console.ReadLine();
            if (valorEnrada != null && valorEnrada != "sa")
            {
                try
                {
                    string Step;
                    string[] ArregloSteps;
                    Step = GetStep(valorEnrada);
                    ArregloSteps = GetSubStepsPorPartes(GetSubSteps(valorEnrada));


                    foreach (var item in ArregloSteps)
                    {
                        string regla = GerearRegla("", "", "", Step, item, "", "", "");
                        Console.WriteLine(regla + "\n");

                    }


                }
                catch (Exception ex)
                {
                    Console.WriteLine("Intenta de nuevo");
                    Console.ReadKey();
                    Console.Clear();

                }
            }
            else
            {
                break;
            }
        } while (valorEnrada != "sa");
    }

    string GerearRegla(string flujoDeRegla, string tipoEncabezado, string tipoDeFlujoParaCondicion, string step, string subStep, string typeSql, string reglafin, string strucparaLeer)
    {
        string regla = "";
        string encambezado = "//*********************************************** PASO *step - Sub *subStep - *tipoEncabezado ***********************************************";
        encambezado = encambezado.Replace(reemplazarStep, step);
        encambezado = encambezado.Replace(reemplazarSubStep, subStep);
        encambezado = encambezado.Replace(reemplazarTipoEncabezado, tipoEncabezado);

        regla += encambezado + "\n\n";


        string sub = subStep.Replace('.', '_');
        string inicio = "rule \"*flujoDeRegla-Step*step-SubStep*subStep\"\r\nagenda-group \"UNINET\"";
        inicio = inicio.Replace(reemplazarStep, step);
        inicio = inicio.Replace(reemplazarSubStep, sub);
        inicio = inicio.Replace(reemplazarFlujoDeRegla, flujoDeRegla);


        regla += inicio + "\n";

        string condicion = "\twhen\r\n\t\tr: HashMap(" + strucparaLeer + "\n\t\t\t\tget(\"type\") == (\"*tipoDeFlujoParaCondicion\") && \r\n\t\t\t\tget(\"step\") == \"*step\" && \r\n\t\t\t\tget(\"subStep\") == \"*subStep\")\r\n\tthen\t";
        condicion = condicion.Replace(reemplazarStep, step);
        condicion = condicion.Replace(reemplazarSubStep, subStep);
        condicion = condicion.Replace(reemplazarTipoDeFlujoParaCondicion, tipoDeFlujoParaCondicion);

        regla += condicion + "\n\n";

        string salida = reglafin + "\r\n\t\t\r\n\t\t//Mapa de salida\r\n\t\toutParams.put(\"type\",\"" + typeSql + "\");\r\n\t\toutParams.put(\"sql\",Query);";

        regla += salida + "\n";

        string cerrar = "\tend\r\n\t\r\n//****************************************************************************************************************";
        regla += "\n" + cerrar;

        return regla;
    }

    string[] GetSubStepsPorPartes(string valores)
    {
        return valores.Split('|');
    }

    string GetSubSteps(string valorEnrada)
    {
        return valorEnrada.Split('-')[1];
    }

    string GetStep(string valorEnrada)
    {
        return valorEnrada.Split('-')[0];
    }

