//constantes para reemplazar
using System.Text;
using System.Text.RegularExpressions;

string reemplazarTipoEncabezado = "*tipoEncabezado";
string reemplazarSubStep = "*subStep";
string reemplazarStep = "*step";
string reemplazarFlujoDeRegla = "*flujoDeRegla";
string reemplazarTipoDeFlujoParaCondicion = "*tipoDeFlujoParaCondicion";
string reemplazarTipoNegocio = "*tipoNegocio";

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
string arroba = "@";
string divEncabezado = "@divisionDeEncabezado";

string anio_ayer = "@anio_ayer";
string mes_ayer = "@mes_ayer";
string dia_ayer = "@dia_ayer";
string anio_semana_ant = "@anio_semana_ant";
string mes_semana_ant = "@mes_semana_ant";
string dia_semana_ant = "@dia_semana_ant";
string anio_mes_ant = "@anio_mes_ant";
string mes_mes_ant = "@mes_mes_ant";
string dia_mes_ant = "@dia_mes_ant";
string fecha_ayer = "@fechAyer";
string fecha_ejecucion = "@fechejecucion";
string fecha_semana = "@fechsemana";
string fecha_mes = "@fechmes";
string primera_fecha = "@primera_fech";
string ultimo_dia= "@ultimo_dia";
string num_acceso = "@num_acceso";
string num_transporte = "@num_transporte";
string valor_inicial_a = "@valor_inicial_a";
string valor_final_a = "@valor_final_a";
string valor_inicial_t = "@valor_inicial_t";
string valor_final_t = "@valor_final_t";

//estructura para obtener datos para concatenar
string leerEsquema_de_trabajo = "$esquema_trabajo: get(\"params\").get(\"esquema_trabajo\"),\n";
string leerEsquema = "                           $esquema: get(\"params\").get(\"esquema\"),\n";
string leerFecha = "                           $fecha: get(\"params\").get(\"fecha\"),\n";
string leerDias_a_procesar = "                           $dias_a_procesar: get(\"params\").get(\"dias_a_procesar\"),\n";
string leerRango_a_considerar = "                           $rango_a_considerar: get(\"params\").get(\"rango_a_considerar\"),\n";

string leer_anio_ayer = "                            $anio_ayer: get(\"params\").get(\"anio_ayer\"),\n";
string leer_mes_ayer = "                            $mes_ayer: get(\"params\").get(\"mes_ayer\"),\n";
string leer_dia_ayer = "                            $dia_ayer: get(\"params\").get(\"dia_ayer\"),\n";
string leer_anio_semana_ant = "                            $anio_semana_ant: get(\"params\").get(\"anio_semana_ant\"),\n";
string leer_mes_semana_ant = "                            $mes_semana_ant: get(\"params\").get(\"mes_semana_ant\"),\n";
string leer_dia_semana_ant = "                            $dia_semana_ant: get(\"params\").get(\"dia_semana_ant\"),\n";
string leer_anio_mes_ant = "                            $anio_mes_ant: get(\"params\").get(\"anio_mes_ant\"),\n";
string leer_mes_mes_ant = "                            $mes_mes_ant: get(\"params\").get(\"mes_mes_ant\"),\n";
string leer_dia_mes_ant = "                            $dia_mes_ant: get(\"params\").get(\"dia_mes_ant\"),\n";
string leer_fecha_ayer = "                            $fecha_ayer: get(\"params\").get(\"fecha_ayer\"),\n";
string leer_fecha_ejecucion = "                            $fecha_ejecucion: get(\"params\").get(\"fecha_ejecucion\"),\n";
string leer_fecha_semana = "                            $fecha_semana: get(\"params\").get(\"fecha_semana\"),\n";
string leer_fecha_mes = "                            $fecha_mes: get(\"params\").get(\"fecha_mes\"),\n";
string leer_primera_fecha = "                            $primera_fecha: get(\"params\").get(\"primera_fecha\"),\n";
string leer_ultimo_dia = "                            $ultimo_dia: get(\"params\").get(\"ultimo_dia\"),\n";
string leer_num_acceso = "                            $num_acceso: get(\"params\").get(\"num_acceso\"),\n";
string leer_num_transporte = "                            $num_transporte: get(\"params\").get(\"num_transporte\"),\n";
string leer_valor_inicial_a = "                            $valor_inicial_a: get(\"params\").get(\"valor_inicial_a\"),\n";
string leer_valor_final_a = "                            $valor_final_a: get(\"params\").get(\"valor_final_a\"),\n";
string leer_valor_inicial_t = "                            $valor_inicial_t: get(\"params\").get(\"valor_inicial_t\"),\n";
string leer_valor_final_t = "                            $valor_final_t: get(\"params\").get(\"valor_final_t\"),\n";

//constantes para concatenar al query
string concatenarEsquema_trabajo = "\n                $esquema_trabajo";
string concatenarEsquema = "\n                $esquema";
string concatenarFecha = "\n                $fecha";
string concatenarDias_a_procesar = "\n                $dias_a_procesar";
string concatenarRango_a_considerar = "\n                $rango_a_considerar";

string concatenaranio_ayer = "\n                $anio_ayer";
string concatenarmes_ayer = "\n                $mes_ayer";
string concatenardia_ayer = "\n                $dia_ayer";
string concatenaranio_semana_ant = "\n                $anio_semana_ant";
string concatenarmes_semana_ant = "\n                $mes_semana_ant";
string concatenardia_semana_ant = "\n                $dia_semana_ant";
string concatenaranio_mes_ant = "\n                $anio_mes_ant";
string concatenarmes_mes_ant = "\n                $mes_mes_ant";
string concatenardia_mes_ant = "\n                $dia_mes_ant";
string concatenarfecha_ayer = "\n                $fecha_ayer";
string concatenarfecha_ejecucion = "\n                $fecha_ejecucion";
string concatenarfecha_semana = "\n                $fecha_semana";
string concatenarfecha_mes = "\n                $fecha_mes";
string concatenarprimera_fecha = "\n                $primera_fecha";
string concatenarultimo_dia = "\n                $ultimo_dia";
string concatenarnum_acceso = "\n                $num_acceso";
string concatenarnum_transporte = "\n                $num_transporte";
string concatenarvalor_inicial_a = "\n                $valor_inicial_a";
string concatenarvalor_final_a = "\n                $valor_final_a";
string concatenarvalor_inicial_t = "\n                $valor_inicial_t";
string concatenarvalor_final_t = "\n                $valor_final_t";

//variables a ocupar
string consarroba = "@";
string concat = "";
string strucparaLeer = "";
int contfechas = 0;
int contdiasaprocesar = 0;
int contesquemas = 0;
int contesquemadeporcentajes = 0;

//String divvisor de encabezados
string DivisorDeEncavezados = "\n//#################################################################################################################################################\r\n//################################################### @divisionDeEncabezado #########################################################################\r\n//#################################################################################################################################################\n\n\n";


String FINALqueryConcatenado = "";


Console.WriteLine("Que deceas hacer?\n\t1 - Generar Reglas \n\t2 - Generar querys \n\t3 - Generar Reglas con querys por un archivo .txt\n\t4 - Generar Reglas ejemplo");
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
    case "4":
        Prueba2();
        break;
    default:

        break;
}


void Prueba2()
{
    Console.Clear();

    Console.Write("Ingresa los nombres del archivo separados por un \"|\"NOTA sin el \".txt\":  ");
    string archivos = Console.ReadLine();

    string[] ArregloDeArchivos = GetSubStepsPorPartes(archivos);


    Console.Write("Ingresa la ruta: sonde se leera el .txt:  ");
    string ruta = Console.ReadLine();

    Console.Clear();
    Console.Write("Escribe el tipo de flujo para la diferenciar la regla ejemplo  :");
    string flujoDeRegla = Console.ReadLine();
    string tipoDeFlujoParaCondicion;//= Console.ReadLine();

    tipoDeFlujoParaCondicion = flujoDeRegla;

    string jj = ruta + @"\ejemplo.txt";
    Console.Clear();
    StreamWriter d=File.CreateText(jj);
    d.Close();
    foreach (string archivo in ArregloDeArchivos)
    {

    string tipoEncabezado = archivo;
    tipoEncabezado = tipoEncabezado.ToUpper();
    //archivo += ".txt";

    string path = ruta.Replace(@"\\", @"\");
    path += @"\" + archivo+".txt";
    string fin = ruta + @"\" + flujoDeRegla + "_" + tipoEncabezado + ".txt";



    try
    {
        Console.Write("Leyendo archivo . . . .");
        Thread.Sleep(2500);
        Console.Clear();

        using (Stream st = File.Open(jj, FileMode.Open, FileAccess.ReadWrite))
        {

                using (StreamWriter escri = new StreamWriter(st))
                {
                    //your code that needs StreamWriter

                    escri.WriteLine(DivisorDeEncavezados.Replace(divEncabezado, tipoEncabezado));

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

                        string regla = GerearRegla("",flujoDeRegla, tipoEncabezado, tipoDeFlujoParaCondicion, Arreglo[0], Arreglo[1], Arreglo[2], reglafin, strucparaLeer);


                        escri.WriteLine(regla + "\n");
                        Console.Write(". ");
                        Thread.Sleep(450);


                    }
                    escri.WriteLine("\n");
                    escri.Close();
                }
                st.Close();
        }

        Console.Write("\n\nArchivo creado con exito . . .\n\r\r\tRUTA DEL ARCHIVO: " + fin);

        Thread.Sleep(500);
    }
    catch (Exception ex)
    {
        Console.Clear();
        Console.Write("No se pudo leer/encontrar el archivo: \nMensaje:\t" + ex.Message);
        File.Delete(fin);
    }

    }

}



void Prueba()
{
    Console.Clear();

    Console.Write("Ingresa el nombre del archivo NOTA sin el  \".txt\":  ");
    string archivo = Console.ReadLine();
    string tipoEncabezado = archivo;
    
    archivo += ".txt";

    Console.Write("Ingresa la ruta: sonde se leera el .txt:  ");
    string ruta = Console.ReadLine();

    Console.Clear();
    Console.Write("Escribe el tipo de flujo para la diferenciar el nombre de la regla  :");
    string flujoDeRegla = Console.ReadLine();
    //string tipoDeFlujoParaCondicion;//= Console.ReadLine();

    //tipoDeFlujoParaCondicion = flujoDeRegla;

    //Console.Clear();
    //Console.Write("Escribe el nombre para diferenciar encabezado de la regla:");
    //string tipoEncabezado = Console.ReadLine();
    tipoEncabezado = tipoEncabezado.ToUpper();

    Console.Clear();
    Console.Write("Escribe el tipo de flujo para la condicion d ela regla \"Equipos o Interfaces\":");
    string tipoDeFlujoParaCondicion = Console.ReadLine();

    Console.Clear();
    Console.Write("Escribe el NOMBR DEL NEGOCIO  :");
    string negocio = Console.ReadLine();



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
            escri.WriteLine(DivisorDeEncavezados.Replace(divEncabezado, tipoEncabezado));

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
                   
                    if (!Arreglo[3].Contains(arroba))
                    {
                        reglafin = GetReglaFinSinArroba(queryConcatenado.ToString(), concat);
                    }
                    else
                    {
                        reglafin = GetReglaFin(queryConcatenado.ToString(), concat);
                    }
                }
                else
                {
                    queryConcatenado = GetQueryNormal(Arreglo[3], salida, queryfinal);

                        reglafin = GetReglaFin(queryConcatenado.ToString(), null);
                    
                }

                string regla = GerearRegla(negocio,flujoDeRegla, tipoEncabezado, tipoDeFlujoParaCondicion, Arreglo[0], Arreglo[1], Arreglo[2], reglafin, strucparaLeer);


                escri.WriteLine(regla + "\n");
                Console.Write(". ");
                Thread.Sleep(450);


            }
            escri.WriteLine("\n");
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

string GetReglaFinSinArroba(string queryConcatenado, string? concat)
{
    return concat == null ? "                //Se Define Query\r\n                String Query = \"" + queryConcatenado + "\";" :
                           "                //Se Define Query\r\n                String Query = String.format(\"" + queryConcatenado + "\");";
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
            //--------------------------------------------------------------------------------------------
            if (queryentrante.Contains(anio_ayer))
            {
                queryfinal = queryentrante.Replace(anio_ayer, "\"" + " + $anio_ayer + " + "\"");
                strucparaLeer += strucparaLeer.Contains(leer_anio_ayer) ? "" : leer_anio_ayer;
            }
            if (queryentrante.Contains(mes_ayer))
            {
                queryfinal = queryentrante.Replace(mes_ayer, "\"" + " + $mes_ayer + " + "\"");
                strucparaLeer += strucparaLeer.Contains(leer_mes_ayer) ? "" : leer_mes_ayer;
            }
            if (queryentrante.Contains(dia_ayer))
            {
                queryfinal = queryentrante.Replace(dia_ayer, "\"" + " + $dia_ayer + " + "\"");
                strucparaLeer += strucparaLeer.Contains(leer_dia_ayer) ? "" : leer_dia_ayer;
            }
            if (queryentrante.Contains(anio_semana_ant))
            {
                queryfinal = queryentrante.Replace(anio_semana_ant, "\"" + " + $anio_semana_ant + " + "\"");
                strucparaLeer += strucparaLeer.Contains(leer_anio_semana_ant) ? "" : leer_anio_semana_ant;
            }
            if (queryentrante.Contains(mes_semana_ant))
            {
                queryfinal = queryentrante.Replace(mes_semana_ant, "\"" + " + $mes_semana_ant + " + "\"");
                strucparaLeer += strucparaLeer.Contains(leer_mes_semana_ant) ? "" : leer_mes_semana_ant;
            }
            if (queryentrante.Contains(dia_semana_ant))
            {
                queryfinal = queryentrante.Replace(dia_semana_ant, "\"" + " + $dia_semana_ant + " + "\"");
                strucparaLeer += strucparaLeer.Contains(leer_dia_semana_ant) ? "" : leer_dia_semana_ant;
            }
            if (queryentrante.Contains(anio_mes_ant))
            {
                queryfinal = queryentrante.Replace(anio_mes_ant, "\"" + " + $anio_mes_ant + " + "\"");
                strucparaLeer += strucparaLeer.Contains(leer_anio_mes_ant) ? "" : leer_anio_mes_ant;
            }
            if (queryentrante.Contains(mes_mes_ant))
            {
                queryfinal = queryentrante.Replace(mes_mes_ant, "\"" + " + $mes_mes_ant + " + "\"");
                strucparaLeer += strucparaLeer.Contains(leer_mes_mes_ant) ? "" : leer_mes_mes_ant;
            }
            if (queryentrante.Contains(dia_mes_ant))
            {
                queryfinal = queryentrante.Replace(dia_mes_ant, "\"" + " + $dia_mes_ant + " + "\"");
                strucparaLeer += strucparaLeer.Contains(leer_dia_mes_ant) ? "" : leer_dia_mes_ant;
            }
            if (queryentrante.Contains(fecha_ayer))
            {
                queryfinal = queryentrante.Replace(fecha_ayer, "\"" + " + $fecha_ayer + " + "\"");
                strucparaLeer += strucparaLeer.Contains(leer_fecha_ayer) ? "" : leer_fecha_ayer;
            }
            if (queryentrante.Contains(fecha_ejecucion))
            {
                queryfinal = queryentrante.Replace(fecha_ejecucion, "\"" + " + $fecha_ejecucion + " + "\"");
                strucparaLeer += strucparaLeer.Contains(leer_fecha_ejecucion) ? "" : leer_fecha_ejecucion;
            }
            if (queryentrante.Contains(fecha_semana))
            {
                queryfinal = queryentrante.Replace(fecha_semana, "\"" + " + $fecha_semana + " + "\"");
                strucparaLeer += strucparaLeer.Contains(leer_fecha_semana) ? "" : leer_fecha_semana;
            }
            if (queryentrante.Contains(fecha_mes))
            {
                queryfinal = queryentrante.Replace(fecha_mes, "\"" + " + $fecha_mes + " + "\"");
                strucparaLeer += strucparaLeer.Contains(leer_fecha_mes) ? "" : leer_fecha_mes;
            }
            if (queryentrante.Contains(primera_fecha))
            {
                queryfinal = queryentrante.Replace(primera_fecha, "\"" + " + $primera_fecha + " + "\"");
                strucparaLeer += strucparaLeer.Contains(leer_primera_fecha) ? "" : leer_primera_fecha;
            }
            if (queryentrante.Contains(ultimo_dia))
            {
                queryfinal = queryentrante.Replace(ultimo_dia, "\"" + " + $ultimo_dia + " + "\"");
                strucparaLeer += strucparaLeer.Contains(leer_ultimo_dia) ? "" : leer_ultimo_dia;
            }
            if (queryentrante.Contains(num_acceso))
            {
                queryfinal = queryentrante.Replace(num_acceso, "\"" + " + $num_acceso + " + "\"");
                strucparaLeer += strucparaLeer.Contains(leer_num_acceso) ? "" : leer_num_acceso;
            }
            if (queryentrante.Contains(num_transporte))
            {
                queryfinal = queryentrante.Replace(num_transporte, "\"" + " + $num_transporte + " + "\"");
                strucparaLeer += strucparaLeer.Contains(leer_num_transporte) ? "" : leer_num_transporte;
            }
            if (queryentrante.Contains(valor_inicial_a))
            {
                queryfinal = queryentrante.Replace(valor_inicial_a, "\"" + " + $valor_inicial_a + " + "\"");
                strucparaLeer += strucparaLeer.Contains(leer_valor_inicial_a) ? "" : leer_valor_inicial_a;
            }
            if (queryentrante.Contains(valor_final_a))
            {
                queryfinal = queryentrante.Replace(valor_final_a, "\"" + " + $valor_final_a + " + "\"");
                strucparaLeer += strucparaLeer.Contains(leer_valor_final_a) ? "" : leer_valor_final_a;
            }
            if (queryentrante.Contains(valor_inicial_t))
            {
                queryfinal = queryentrante.Replace(valor_inicial_t, "\"" + " + $valor_inicial_t + " + "\"");
                strucparaLeer += strucparaLeer.Contains(leer_valor_inicial_t) ? "" : leer_valor_inicial_t;
            }
            if (queryentrante.Contains(valor_final_t))
            {
                queryfinal = queryentrante.Replace(valor_final_t, "\"" + " + $valor_final_t + " + "\"");
                strucparaLeer += strucparaLeer.Contains(leer_valor_final_t) ? "" : leer_valor_final_t;
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

        //-----------------------------------------------------------------------------------------------------

        if (buscar.Contains(anio_ayer))
        {
            queryfinal = buscar.Replace(anio_ayer, "\"" + " + $anio_ayer + " + "\".");
            strucparaLeer += strucparaLeer.Contains(leer_anio_ayer) ? "" : leer_anio_ayer;
            queryfinal += restodequery;
            return GetQueryNormal(queryfinal, salida, queryfinal);
        }
        if (buscar.Contains(mes_ayer))
        {
            queryfinal = buscar.Replace(mes_ayer, "\"" + " + $mes_ayer + " + "\".");
            strucparaLeer += strucparaLeer.Contains(leer_mes_ayer) ? "" : leer_mes_ayer;
            queryfinal += restodequery;
            return GetQueryNormal(queryfinal, salida, queryfinal);
        }
        if (buscar.Contains(dia_ayer))
        {
            queryfinal = buscar.Replace(dia_ayer, "\"" + " + $dia_ayer + " + "\".");
            strucparaLeer += strucparaLeer.Contains(leer_dia_ayer) ? "" : leer_dia_ayer;
            queryfinal += restodequery;
            return GetQueryNormal(queryfinal, salida, queryfinal);
        }
        if (buscar.Contains(anio_semana_ant))
        {
            queryfinal = buscar.Replace(anio_semana_ant, "\"" + " + $anio_semana_ant + " + "\".");
            strucparaLeer += strucparaLeer.Contains(leer_anio_semana_ant) ? "" : leer_anio_semana_ant;
            queryfinal += restodequery;
            return GetQueryNormal(queryfinal, salida, queryfinal);
        }
        if (buscar.Contains(mes_semana_ant))
        {
            queryfinal = buscar.Replace(mes_semana_ant, "\"" + " + $mes_semana_ant + " + "\".");
            strucparaLeer += strucparaLeer.Contains(leer_mes_semana_ant) ? "" : leer_mes_semana_ant;
            queryfinal += restodequery;
            return GetQueryNormal(queryfinal, salida, queryfinal);
        }
        if (buscar.Contains(dia_semana_ant))
        {
            queryfinal = buscar.Replace(dia_semana_ant, "\"" + " + $dia_semana_ant + " + "\".");
            strucparaLeer += strucparaLeer.Contains(leer_dia_semana_ant) ? "" : leer_dia_semana_ant;
            queryfinal += restodequery;
            return GetQueryNormal(queryfinal, salida, queryfinal);
        }
        if (buscar.Contains(anio_mes_ant))
        {
            queryfinal = buscar.Replace(anio_mes_ant, "\"" + " + $anio_mes_ant + " + "\".");
            strucparaLeer += strucparaLeer.Contains(leer_anio_mes_ant) ? "" : leer_anio_mes_ant;
            queryfinal += restodequery;
            return GetQueryNormal(queryfinal, salida, queryfinal);
        }
        if (buscar.Contains(mes_mes_ant))
        {
            queryfinal = buscar.Replace(mes_mes_ant, "\"" + " + $mes_mes_ant + " + "\".");
            strucparaLeer += strucparaLeer.Contains(leer_mes_mes_ant) ? "" : leer_mes_mes_ant;
            queryfinal += restodequery;
            return GetQueryNormal(queryfinal, salida, queryfinal);
        }
        if (buscar.Contains(dia_mes_ant))
        {
            queryfinal = buscar.Replace(dia_mes_ant, "\"" + " + $dia_mes_ant + " + "\".");
            strucparaLeer += strucparaLeer.Contains(leer_dia_mes_ant) ? "" : leer_dia_mes_ant;
            queryfinal += restodequery;
            return GetQueryNormal(queryfinal, salida, queryfinal);
        }
        if (buscar.Contains(fecha_ayer))
        {
            queryfinal = buscar.Replace(fecha_ayer, "\"" + " + $fecha_ayer + " + "\".");
            strucparaLeer += strucparaLeer.Contains(leer_fecha_ayer) ? "" : leer_fecha_ayer;
            queryfinal += restodequery;
            return GetQueryNormal(queryfinal, salida, queryfinal);
        }
        if (buscar.Contains(fecha_ejecucion))
        {
            queryfinal = buscar.Replace(fecha_ejecucion, "\"" + " + $fecha_ejecucion + " + "\".");
            strucparaLeer += strucparaLeer.Contains(leer_fecha_ejecucion) ? "" : leer_fecha_ejecucion;
            queryfinal += restodequery;
            return GetQueryNormal(queryfinal, salida, queryfinal);
        }
        if (buscar.Contains(fecha_semana))
        {
            queryfinal = buscar.Replace(fecha_semana, "\"" + " + $fecha_semana + " + "\".");
            strucparaLeer += strucparaLeer.Contains(leer_fecha_semana) ? "" : leer_fecha_semana;
            queryfinal += restodequery;
            return GetQueryNormal(queryfinal, salida, queryfinal);
        }
        if (buscar.Contains(fecha_mes))
        {
            queryfinal = buscar.Replace(fecha_mes, "\"" + " + $fecha_mes + " + "\".");
            strucparaLeer += strucparaLeer.Contains(leer_fecha_mes) ? "" : leer_fecha_mes;
            queryfinal += restodequery;
            return GetQueryNormal(queryfinal, salida, queryfinal);
        }
        if (buscar.Contains(primera_fecha))
        {
            queryfinal = buscar.Replace(primera_fecha, "\"" + " + $primera_fecha + " + "\".");
            strucparaLeer += strucparaLeer.Contains(leer_primera_fecha) ? "" : leer_primera_fecha;
            queryfinal += restodequery;
            return GetQueryNormal(queryfinal, salida, queryfinal);
        }
        if (buscar.Contains(ultimo_dia))
        {
            queryfinal = buscar.Replace(ultimo_dia, "\"" + " + $ultimo_dia + " + "\".");
            strucparaLeer += strucparaLeer.Contains(leer_ultimo_dia) ? "" : leer_ultimo_dia;
            queryfinal += restodequery;
            return GetQueryNormal(queryfinal, salida, queryfinal);
        }
        if (buscar.Contains(num_acceso))
        {
            queryfinal = buscar.Replace(num_acceso, "\"" + " + $num_acceso + " + "\".");
            strucparaLeer += strucparaLeer.Contains(leer_num_acceso) ? "" : leer_num_acceso;
            queryfinal += restodequery;
            return GetQueryNormal(queryfinal, salida, queryfinal);
        }
        if (buscar.Contains(num_transporte))
        {
            queryfinal = buscar.Replace(num_transporte, "\"" + " + $num_transporte + " + "\".");
            strucparaLeer += strucparaLeer.Contains(leer_num_transporte) ? "" : leer_num_transporte;
            queryfinal += restodequery;
            return GetQueryNormal(queryfinal, salida, queryfinal);
        }
        if (buscar.Contains(valor_inicial_a))
        {
            queryfinal = buscar.Replace(valor_inicial_a, "\"" + " + $valor_inicial_a + " + "\".");
            strucparaLeer += strucparaLeer.Contains(leer_valor_inicial_a) ? "" : leer_valor_inicial_a;
            queryfinal += restodequery;
            return GetQueryNormal(queryfinal, salida, queryfinal);
        }
        if (buscar.Contains(valor_final_a))
        {
            queryfinal = buscar.Replace(valor_final_a, "\"" + " + $valor_final_a + " + "\".");
            strucparaLeer += strucparaLeer.Contains(leer_valor_final_a) ? "" : leer_valor_final_a;
            queryfinal += restodequery;
            return GetQueryNormal(queryfinal, salida, queryfinal);
        }
        if (buscar.Contains(valor_inicial_t))
        {
            queryfinal = buscar.Replace(valor_inicial_t, "\"" + " + $valor_inicial_t + " + "\".");
            strucparaLeer += strucparaLeer.Contains(leer_valor_inicial_t) ? "" : leer_valor_inicial_t;
            queryfinal += restodequery;
            return GetQueryNormal(queryfinal, salida, queryfinal);
        }
        if (buscar.Contains(valor_final_t))
        {
            queryfinal = buscar.Replace(valor_final_t, "\"" + " + $valor_final_t + " + "\".");
            strucparaLeer += strucparaLeer.Contains(leer_valor_final_t) ? "" : leer_valor_final_t;
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

            //------------------------------------------------------------------------------------------------------

            if (queryentrante.Contains(anio_ayer))
            {
                queryfinal += queryentrante.Replace(anio_ayer, reemplazoDeFecha);
                concat += concatenaranio_ayer;
                strucparaLeer += strucparaLeer.Contains(leer_anio_ayer) ? "" : leer_anio_ayer;

            }
            if (queryentrante.Contains(mes_ayer))
            {
                queryfinal += queryentrante.Replace(mes_ayer, reemplazoDeFecha);
                concat += concatenarmes_ayer;
                strucparaLeer += strucparaLeer.Contains(leer_mes_ayer) ? "" : leer_mes_ayer;

            }
            if (queryentrante.Contains(dia_ayer))
            {
                queryfinal += queryentrante.Replace(dia_ayer, reemplazoDeFecha);
                concat += concatenardia_ayer;
                strucparaLeer += strucparaLeer.Contains(leer_dia_ayer) ? "" : leer_dia_ayer;

            }
            if (queryentrante.Contains(anio_semana_ant))
            {
                queryfinal += queryentrante.Replace(anio_semana_ant, reemplazoDeFecha);
                concat += concatenaranio_semana_ant;
                strucparaLeer += strucparaLeer.Contains(leer_anio_semana_ant) ? "" : leer_anio_semana_ant;

            }
            if (queryentrante.Contains(mes_semana_ant))
            {
                queryfinal += queryentrante.Replace(mes_semana_ant, reemplazoDeFecha);
                concat += concatenarmes_semana_ant;
                strucparaLeer += strucparaLeer.Contains(leer_mes_semana_ant) ? "" : leer_mes_semana_ant;

            }
            if (queryentrante.Contains(dia_semana_ant))
            {
                queryfinal += queryentrante.Replace(dia_semana_ant, reemplazoDeFecha);
                concat += concatenardia_semana_ant;
                strucparaLeer += strucparaLeer.Contains(leer_dia_semana_ant) ? "" : leer_dia_semana_ant;

            }
            if (queryentrante.Contains(anio_mes_ant))
            {
                queryfinal += queryentrante.Replace(anio_mes_ant, reemplazoDeFecha);
                concat += concatenaranio_mes_ant;
                strucparaLeer += strucparaLeer.Contains(leer_anio_mes_ant) ? "" : leer_anio_mes_ant;

            }
            if (queryentrante.Contains(mes_mes_ant))
            {
                queryfinal += queryentrante.Replace(mes_mes_ant, reemplazoDeFecha);
                concat += concatenarmes_mes_ant;
                strucparaLeer += strucparaLeer.Contains(leer_mes_mes_ant) ? "" : leer_mes_mes_ant;

            }
            if (queryentrante.Contains(dia_mes_ant))
            {
                queryfinal += queryentrante.Replace(dia_mes_ant, reemplazoDeFecha);
                concat += concatenardia_mes_ant;
                strucparaLeer += strucparaLeer.Contains(leer_dia_mes_ant) ? "" : leer_dia_mes_ant;

            }
            if (queryentrante.Contains(fecha_ayer))
            {
                queryfinal += queryentrante.Replace(fecha_ayer, reemplazoDeFecha);
                concat += concatenarfecha_ayer;
                strucparaLeer += strucparaLeer.Contains(leer_fecha_ayer) ? "" : leer_fecha_ayer;

            }
            if (queryentrante.Contains(fecha_ejecucion))
            {
                queryfinal += queryentrante.Replace(fecha_ejecucion, reemplazoDeFecha);
                concat += concatenarfecha_ejecucion;
                strucparaLeer += strucparaLeer.Contains(leer_fecha_ejecucion) ? "" : leer_fecha_ejecucion;

            }
            if (queryentrante.Contains(fecha_semana))
            {
                queryfinal += queryentrante.Replace(fecha_semana, reemplazoDeFecha);
                concat += concatenarfecha_semana;
                strucparaLeer += strucparaLeer.Contains(leer_fecha_semana) ? "" : leer_fecha_semana;

            }
            if (queryentrante.Contains(fecha_mes))
            {
                queryfinal += queryentrante.Replace(fecha_mes, reemplazoDeFecha);
                concat += concatenarfecha_mes;
                strucparaLeer += strucparaLeer.Contains(leer_fecha_mes) ? "" : leer_fecha_mes;

            }
            if (queryentrante.Contains(primera_fecha))
            {
                queryfinal += queryentrante.Replace(primera_fecha, reemplazoDeFecha);
                concat += concatenarprimera_fecha;
                strucparaLeer += strucparaLeer.Contains(leer_primera_fecha) ? "" : leer_primera_fecha;

            }
            if (queryentrante.Contains(ultimo_dia))
            {
                queryfinal += queryentrante.Replace(ultimo_dia, reemplazoDeFecha);
                concat += concatenarultimo_dia;
                strucparaLeer += strucparaLeer.Contains(leer_ultimo_dia) ? "" : leer_ultimo_dia;

            }
            if (queryentrante.Contains(num_acceso))
            {
                queryfinal += queryentrante.Replace(num_acceso, reemplazoDeDatoNormal);
                concat += concatenarnum_acceso;
                strucparaLeer += strucparaLeer.Contains(leer_num_acceso) ? "" : leer_num_acceso;

            }
            if (queryentrante.Contains(num_transporte))
            {
                queryfinal += queryentrante.Replace(num_transporte, reemplazoDeDatoNormal);
                concat += concatenarnum_transporte;
                strucparaLeer += strucparaLeer.Contains(leer_num_transporte) ? "" : leer_num_transporte;

            }
            if (queryentrante.Contains(valor_inicial_a))
            {
                queryfinal += queryentrante.Replace(valor_inicial_a, reemplazoDeDatoNormal);
                concat += concatenarvalor_inicial_a;
                strucparaLeer += strucparaLeer.Contains(leer_valor_inicial_a) ? "" : leer_valor_inicial_a;

            }
            if (queryentrante.Contains(valor_final_a))
            {
                queryfinal += queryentrante.Replace(valor_final_a, reemplazoDeDatoNormal);
                concat += concatenarvalor_final_a;
                strucparaLeer += strucparaLeer.Contains(leer_valor_final_a) ? "" : leer_valor_final_a;

            }
            if (queryentrante.Contains(valor_inicial_t))
            {
                queryfinal += queryentrante.Replace(valor_inicial_t, reemplazoDeDatoNormal);
                concat += concatenarvalor_inicial_t;
                strucparaLeer += strucparaLeer.Contains(leer_valor_inicial_t) ? "" : leer_valor_inicial_t;

            }
            if (queryentrante.Contains(valor_final_t))
            {
                queryfinal += queryentrante.Replace(valor_final_t, reemplazoDeDatoNormal);
                concat += concatenarvalor_final_t;
                strucparaLeer += strucparaLeer.Contains(leer_valor_final_t) ? "" : leer_valor_final_t;

            }

            return queryfinal;
        }
        string buscar = queryentrante.Substring(0, fir2 + primerencuentro + 1);

        if (buscar.Contains(esquema_trabajo))
        {
            queryfinal += buscar.Replace(esquema_trabajo, reemplazoDeEsquemaEsquema_trabajo);
            salida = queryentrante.Substring(buscar.Length);
            concat += concatenarEsquema_trabajo + ",";
            strucparaLeer += strucparaLeer.Contains(leerEsquema_de_trabajo) ? "" : leerEsquema_de_trabajo;
            return GetQueryStringFormat(salida, salida, queryfinal);
        }
        if (buscar.Contains(esquema))
        {
            queryfinal += buscar.Replace(esquema, reemplazoDeEsquemaEsquema_trabajo);
            salida = queryentrante.Substring(buscar.Length);
            concat += concatenarEsquema + ",";
            strucparaLeer += strucparaLeer.Contains(leerEsquema) ? "" : leerEsquema;

            return GetQueryStringFormat(salida, salida, queryfinal);
        }
        if (buscar.Contains(fecha))
        {
            queryfinal += buscar.Replace(fecha, reemplazoDeFecha);
            salida = queryentrante.Substring(buscar.Length);
            concat += concatenarFecha + ",";
            strucparaLeer += strucparaLeer.Contains(leerFecha) ? "" : leerFecha;

            return GetQueryStringFormat(salida, salida, queryfinal);
        }
        if (buscar.Contains(dias_a_procesar))
        {
            queryfinal += buscar.Replace(dias_a_procesar, reemplazoDeDatoNormal);
            salida = queryentrante.Substring(buscar.Length);
            concat += concatenarDias_a_procesar + ",";
            strucparaLeer += strucparaLeer.Contains(leerDias_a_procesar) ? "" : leerDias_a_procesar;
            return GetQueryStringFormat(salida, salida, queryfinal);
        }
        if (buscar.Contains(rango_a_considerar))
        {
            queryfinal += buscar.Replace(rango_a_considerar, reemplazoDeDatoNormal);
            salida = queryentrante.Substring(buscar.Length);
            concat += concatenarRango_a_considerar + ",";
            strucparaLeer += strucparaLeer.Contains(leerRango_a_considerar) ? "" : leerRango_a_considerar;
            return GetQueryStringFormat(salida, salida, queryfinal);
        }

        //----------------------------------------------------------------------------------------------------

        if (buscar.Contains(anio_ayer))
        {
            queryfinal += buscar.Replace(anio_ayer, reemplazoDeFecha);
            salida = queryentrante.Substring(buscar.Length);
            concat += concatenaranio_ayer + ",";
            strucparaLeer += strucparaLeer.Contains(leer_anio_ayer) ? "" : leer_anio_ayer;
            return GetQueryStringFormat(salida, salida, queryfinal);
        }
        if (buscar.Contains(mes_ayer))
        {
            queryfinal += buscar.Replace(mes_ayer, reemplazoDeFecha);
            salida = queryentrante.Substring(buscar.Length);
            concat += concatenarmes_ayer + ",";
            strucparaLeer += strucparaLeer.Contains(leer_mes_ayer) ? "" : leer_mes_ayer;
            return GetQueryStringFormat(salida, salida, queryfinal);
        }
        if (buscar.Contains(dia_ayer))
        {
            queryfinal += buscar.Replace(dia_ayer, reemplazoDeFecha);
            salida = queryentrante.Substring(buscar.Length);
            concat += concatenardia_ayer + ",";
            strucparaLeer += strucparaLeer.Contains(leer_dia_ayer) ? "" : leer_dia_ayer;
            return GetQueryStringFormat(salida, salida, queryfinal);
        }
        if (buscar.Contains(anio_semana_ant))
        {
            queryfinal += buscar.Replace(anio_semana_ant, reemplazoDeFecha);
            salida = queryentrante.Substring(buscar.Length);
            concat += concatenaranio_semana_ant + ",";
            strucparaLeer += strucparaLeer.Contains(leer_anio_semana_ant) ? "" : leer_anio_semana_ant;
            return GetQueryStringFormat(salida, salida, queryfinal);
        }
        if (buscar.Contains(mes_semana_ant))
        {
            queryfinal += buscar.Replace(mes_semana_ant, reemplazoDeFecha);
            salida = queryentrante.Substring(buscar.Length);
            concat += concatenarmes_semana_ant + ",";
            strucparaLeer += strucparaLeer.Contains(leer_mes_semana_ant) ? "" : leer_mes_semana_ant;
            return GetQueryStringFormat(salida, salida, queryfinal);
        }
        if (buscar.Contains(dia_semana_ant))
        {
            queryfinal += buscar.Replace(dia_semana_ant, reemplazoDeFecha);
            salida = queryentrante.Substring(buscar.Length);
            concat += concatenardia_semana_ant + ",";
            strucparaLeer += strucparaLeer.Contains(leer_dia_semana_ant) ? "" : leer_dia_semana_ant;
            return GetQueryStringFormat(salida, salida, queryfinal);
        }
        if (buscar.Contains(anio_mes_ant))
        {
            queryfinal += buscar.Replace(anio_mes_ant, reemplazoDeFecha);
            salida = queryentrante.Substring(buscar.Length);
            concat += concatenaranio_mes_ant + ",";
            strucparaLeer += strucparaLeer.Contains(leer_anio_mes_ant) ? "" : leer_anio_mes_ant;
            return GetQueryStringFormat(salida, salida, queryfinal);
        }
        if (buscar.Contains(mes_mes_ant))
        {
            queryfinal += buscar.Replace(mes_mes_ant, reemplazoDeFecha);
            salida = queryentrante.Substring(buscar.Length);
            concat += concatenarmes_mes_ant + ",";
            strucparaLeer += strucparaLeer.Contains(leer_mes_mes_ant) ? "" : leer_mes_mes_ant;
            return GetQueryStringFormat(salida, salida, queryfinal);
        }
        if (buscar.Contains(dia_mes_ant))
        {
            queryfinal += buscar.Replace(dia_mes_ant, reemplazoDeFecha);
            salida = queryentrante.Substring(buscar.Length);
            concat += concatenardia_mes_ant + ",";
            strucparaLeer += strucparaLeer.Contains(leer_dia_mes_ant) ? "" : leer_dia_mes_ant;
            return GetQueryStringFormat(salida, salida, queryfinal);
        }
        if (buscar.Contains(fecha_ayer))
        {
            queryfinal += buscar.Replace(fecha_ayer, reemplazoDeFecha);
            salida = queryentrante.Substring(buscar.Length);
            concat += concatenarfecha_ayer + ",";
            strucparaLeer += strucparaLeer.Contains(leer_fecha_ayer) ? "" : leer_fecha_ayer;
            return GetQueryStringFormat(salida, salida, queryfinal);
        }
        if (buscar.Contains(fecha_ejecucion))
        {
            queryfinal += buscar.Replace(fecha_ejecucion, reemplazoDeFecha);
            salida = queryentrante.Substring(buscar.Length);
            concat += concatenarfecha_ejecucion + ",";
            strucparaLeer += strucparaLeer.Contains(leer_fecha_ejecucion) ? "" : leer_fecha_ejecucion;
            return GetQueryStringFormat(salida, salida, queryfinal);
        }
        if (buscar.Contains(fecha_semana))
        {
            queryfinal += buscar.Replace(fecha_semana, reemplazoDeFecha);
            salida = queryentrante.Substring(buscar.Length);
            concat += concatenarfecha_semana + ",";
            strucparaLeer += strucparaLeer.Contains(leer_fecha_semana) ? "" : leer_fecha_semana;
            return GetQueryStringFormat(salida, salida, queryfinal);
        }
        if (buscar.Contains(fecha_mes))
        {
            queryfinal += buscar.Replace(fecha_mes, reemplazoDeFecha);
            salida = queryentrante.Substring(buscar.Length);
            concat += concatenarfecha_mes + ",";
            strucparaLeer += strucparaLeer.Contains(leer_fecha_mes) ? "" : leer_fecha_mes;
            return GetQueryStringFormat(salida, salida, queryfinal);
        }
        if (buscar.Contains(primera_fecha))
        {
            queryfinal += buscar.Replace(primera_fecha, reemplazoDeFecha);
            salida = queryentrante.Substring(buscar.Length);
            concat += concatenarprimera_fecha + ",";
            strucparaLeer += strucparaLeer.Contains(leer_primera_fecha) ? "" : leer_primera_fecha;
            return GetQueryStringFormat(salida, salida, queryfinal);
        }
        if (buscar.Contains(ultimo_dia))
        {
            queryfinal += buscar.Replace(ultimo_dia, reemplazoDeFecha);
            salida = queryentrante.Substring(buscar.Length);
            concat += concatenarultimo_dia + ",";
            strucparaLeer += strucparaLeer.Contains(leer_ultimo_dia) ? "" : leer_ultimo_dia;
            return GetQueryStringFormat(salida, salida, queryfinal);
        }
        if (buscar.Contains(num_acceso))
        {
            queryfinal += buscar.Replace(num_acceso, reemplazoDeDatoNormal);
            salida = queryentrante.Substring(buscar.Length);
            concat += concatenarnum_acceso + ",";
            strucparaLeer += strucparaLeer.Contains(leer_num_acceso) ? "" : leer_num_acceso;
            return GetQueryStringFormat(salida, salida, queryfinal);
        }
        if (buscar.Contains(num_transporte))
        {
            queryfinal += buscar.Replace(num_transporte, reemplazoDeDatoNormal);
            salida = queryentrante.Substring(buscar.Length);
            concat += concatenarnum_transporte + ",";
            strucparaLeer += strucparaLeer.Contains(leer_num_transporte) ? "" : leer_num_transporte;
            return GetQueryStringFormat(salida, salida, queryfinal);
        }
        if (buscar.Contains(valor_inicial_a))
        {
            queryfinal += buscar.Replace(valor_inicial_a, reemplazoDeDatoNormal);
            salida = queryentrante.Substring(buscar.Length);
            concat += concatenarvalor_inicial_a + ",";
            strucparaLeer += strucparaLeer.Contains(leer_valor_inicial_a) ? "" : leer_valor_inicial_a;
            return GetQueryStringFormat(salida, salida, queryfinal);
        }
        if (buscar.Contains(valor_final_a))
        {
            queryfinal += buscar.Replace(valor_final_a, reemplazoDeDatoNormal);
            salida = queryentrante.Substring(buscar.Length);
            concat += concatenarvalor_final_a + ",";
            strucparaLeer += strucparaLeer.Contains(leer_valor_final_a) ? "" : leer_valor_final_a;
            return GetQueryStringFormat(salida, salida, queryfinal);
        }
        if (buscar.Contains(valor_inicial_t))
        {
            queryfinal += buscar.Replace(valor_inicial_t, reemplazoDeDatoNormal);
            salida = queryentrante.Substring(buscar.Length);
            concat += concatenarvalor_inicial_t + ",";
            strucparaLeer += strucparaLeer.Contains(leer_valor_inicial_t) ? "" : leer_valor_inicial_t;
            return GetQueryStringFormat(salida, salida, queryfinal);
        }
        if (buscar.Contains(valor_final_t))
        {
            queryfinal += buscar.Replace(valor_final_t, reemplazoDeDatoNormal);
            salida = queryentrante.Substring(buscar.Length);
            concat += concatenarvalor_final_t + ",";
            strucparaLeer += strucparaLeer.Contains(leer_valor_final_t) ? "" : leer_valor_final_t;
            return GetQueryStringFormat(salida, salida, queryfinal);
        }
    }

    return queryentrante.Contains(consarroba)?queryfinal:queryentrante;

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
                        string regla = GerearRegla("","", "", "", Step, item, "", "", "");
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

    string GerearRegla(string Negocio,string flujoDeRegla, string tipoEncabezado, string tipoDeFlujoParaCondicion, string step, string subStep, string typeSql, string reglafin, string strucparaLeer)
    {
        string regla = "";
        string encambezado = "//*********************************************** PASO *step - Sub *subStep - *tipoEncabezado ***********************************************";
        encambezado = encambezado.Replace(reemplazarStep, step);
        encambezado = encambezado.Replace(reemplazarSubStep, subStep);
        encambezado = encambezado.Replace(reemplazarTipoEncabezado, tipoEncabezado);

        regla += encambezado + "\n\n";


        string sub = subStep.Replace('.', '_');
        string inicio = "rule \"*flujoDeRegla-Step*step-SubStep*subStep\"\r\nagenda-group \"*tipoNegocio\"";
        inicio = inicio.Replace(reemplazarTipoNegocio,Negocio);
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

