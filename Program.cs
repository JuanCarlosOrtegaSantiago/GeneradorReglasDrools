//constantes para reemplazar
using GeneradorReglasDrools;
using System.Reflection.Metadata;
using System.Text;
using System.Text.RegularExpressions;

string reemplazarTipoEncabezado = "*tipoEncabezado";
string reemplazarSubStep = "*subStep";
string reemplazarStep = "*step";
string reemplazarFlujoDeRegla = "*flujoDeRegla";
string reemplazarTipoDeFlujoParaCondicion = "*tipoDeFlujoParaCondicion";
string reemplazarTipoNegocio = "*tipoNegocio";

//constantes para realizar reemplazo
string reemplazoDeDatoNormal = "%s";
string reemplazoDeFecha = "'%s'";

//parametros a buscar
string fecha = "@fecha";
string dias_a_procesar = "@dias_a_procesar";
string esquema = "@esquema.";
string esquema_trabajo = "@esquema_trabajo.";
string porcentaje = "%";
string arroba = "@";
string divEncabezado = "@divisionDeEncabezado";


//estructura para obtener datos para concatenar
string leerParam = "                           $parametro: get(\"params\").get(\"parametro\"),\n";
//constantes para concatenar al query
string concatenarParametro = "\n                $parametro";

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

Console.WriteLine("Que deceas hacer?\n\t1 - Generar Reglas \n\t2 - Generar querys \n\t3 - Generar Reglas con querys por un archivo .txt\n\t4 - Generar Reglas ejemplo");
string op=Console.ReadLine();
var j=prop.MiLeyPrincipal;
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

                string typeSQL = getTypeSQL(Arreglo[2]);



                if (!Arreglo[2].Contains(porcentaje))
                {
                    queryConcatenado = GetQueryStringFormat(Arreglo[2], salida, queryfinal);
                    reglafin = GetReglaFin(queryConcatenado.ToString(), concat);
                   
                    if (!Arreglo[2].Contains(arroba))
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
                    queryConcatenado = GetQueryNormal(Arreglo[2], salida, queryfinal);

                        reglafin = GetReglaFin(queryConcatenado.ToString(), null);
                    
                }

                string regla = GerearRegla(negocio,flujoDeRegla, tipoEncabezado, tipoDeFlujoParaCondicion, Arreglo[0], Arreglo[1], typeSQL, reglafin, strucparaLeer);


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

string getTypeSQL(string Query)
{
    int h = Query.IndexOf(" ");
    string SQL = Query.Substring(0, h).ToUpper();

    List<string> DML = new List<string>();
    DML.Add("REFRESH");
    DML.Add("INSERT");
    DML.Add("UPDATE");
    DML.Add("DELETE");

    List<string> DDL = new List<string>();
    DDL.Add("CREATE");
    DDL.Add("DROP");
    DDL.Add("ALTER");
    DDL.Add("TRUNCATE");

    string ret="";

    if (DML.Contains(SQL))
    {
        ret ="DML";
    }
    else if (DDL.Contains(SQL))
    {
        ret ="DDL";
    }
    else
    {
        ret = "SELECT";
    }
    return ret;

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

            string parametro = GetPalabra(queryentrante);
            if (parametro.Length < 1)
                return "";

            string lectura = leerParam.Replace("parametro", parametro.Substring(1));
            string remplazo = parametro.Contains("fecha")? string.Format("'\" + ${0} + \"'", parametro.Substring(1)): string.Format("\" + ${0} + \"", parametro.Substring(1));
            
            queryfinal = queryentrante.Replace(parametro, remplazo);
            strucparaLeer += strucparaLeer.Contains(lectura) ? "" : lectura;

            //if (queryentrante.Contains(esquema_trabajo))
            //{
            //    queryfinal = queryentrante.Replace(esquema_trabajo, "\"" + " + $esquema_trabajo + " + "\".");
            //    strucparaLeer+=strucparaLeer.Contains(leerEsquema_de_trabajo)? "": leerEsquema_de_trabajo;
            //}
            
            return queryfinal;
        }
        
        string buscar = queryentrante.Substring(0, fir2 + first + 1);
        string restodequery = queryentrante.Substring(buscar.Length);

        string k = GetPalabra(buscar);
        if (k.Length < 1)
            return "";

        string loa = leerParam.Replace("parametro", k.Substring(1));
        string remplace = k.Contains("fecha")? string.Format("'\" + ${0} + \"'", k.Substring(1)): string.Format("\" + ${0} + \"", k.Substring(1));
                
        queryfinal = buscar.Replace(k, remplace);
        strucparaLeer += strucparaLeer.Contains(loa) ? "" : loa;
        queryfinal += restodequery;
        return GetQueryNormal(queryfinal, salida, queryfinal);

        //if (buscar.Contains(esquema_trabajo))
        //{
            //queryfinal = buscar.Replace(esquema_trabajo, "\""+ " + $esquema_trabajo + " + "\".");
        //    strucparaLeer += strucparaLeer.Contains(leerEsquema_de_trabajo) ? "" : leerEsquema_de_trabajo;
        //    queryfinal += restodequery;
        //    return GetQueryNormal(queryfinal, salida, queryfinal);
        //}

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
            string k = GetPalabra(queryentrante);
            if (k.Length < 1)
                return "";

            string typeRempl = k.Contains("fecha")? reemplazoDeFecha:reemplazoDeDatoNormal;
            

            string loa=leerParam.Replace("parametro", k.Substring(1));

                queryfinal += queryentrante.Replace(k, typeRempl);
                concat += concatenarParametro.Replace("parametro", k.Substring(1));
                strucparaLeer += strucparaLeer.Contains(loa) ? "" : loa;
            

            //if (queryentrante.Contains(esquema_trabajo))
            //{
            //    queryfinal += queryentrante.Replace(esquema_trabajo, reemplazoDeEsquemaEsquema_trabajo);
            //    concat += concatenarEsquema_trabajo;
            //    strucparaLeer += strucparaLeer.Contains(leerEsquema_de_trabajo) ? "" : leerEsquema_de_trabajo;
            //}
            

            return queryfinal;
        }
        
        string buscar = queryentrante.Substring(0, fir2 + primerencuentro + 1);

        string n = GetPalabra(buscar);

        if (n.Length < 1)
            return "";
        
        string typeRem = n.Contains("fecha")? reemplazoDeFecha: reemplazoDeDatoNormal;
        
        string lo = leerParam.Replace("parametro", n.Substring(1));

        queryfinal += buscar.Replace(n, typeRem);
        salida = queryentrante.Substring(buscar.Length);
        concat += concatenarParametro.Replace("parametro", n.Substring(1)) + ",";
        strucparaLeer += strucparaLeer.Contains(lo) ? "" : lo;

        return GetQueryStringFormat(salida, salida, queryfinal);


        //{
        //    queryfinal += buscar.Replace(valor_final_t, reemplazoDeDatoNormal);
        //    salida = queryentrante.Substring(buscar.Length);
        //    concat += concatenarvalor_final_t + ",";
        //    strucparaLeer += strucparaLeer.Contains(leer_valor_final_t) ? "" : leer_valor_final_t;
        //    return GetQueryStringFormat(salida, salida, queryfinal);
        //}
    }

    return queryentrante.Contains(consarroba)?queryfinal:queryentrante;

}

string GetPalabra(string queryentrante)
{
    int prim = queryentrante.IndexOf("@");
    string g=queryentrante.Substring(prim);

    int[] valores = new int[4]; 

    valores[0]=g.IndexOf(" ");
    valores[1] = g.IndexOf(".");
    valores[2] = g.IndexOf(")");
    valores[3] = g.IndexOf(",");

    List<string> param= new List<string>();

    foreach (var item in valores)
    {
        if (item >= 0)
        {
            param.Add(queryentrante.Substring(prim, item));
        }
    }
    string parametrofinal = "";
    foreach (var parametro in param)
    {
        if (Const.parametros.Contains(parametro))
        {
            parametrofinal=parametro;
            break;
        }
    }
    if (!(parametrofinal.Length > 1))
    {
        string h = string.Join(",", param);
        Console.WriteLine("=> NO HAY PARAMETRO ESTABLECIDO EN LAS CONSTANTES [ {0} ] <=", string.Join(",", param));

    }

    return parametrofinal;
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

