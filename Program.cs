//constantes para reemplazar
using GeneradorReglasDrools;
using System.Diagnostics;

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

//String divvisor de encabezados
string DivisorDeEncavezados = "\n//#################################################################################################################################################\r\n//################################################### @divisionDeEncabezado #########################################################################\r\n//#################################################################################################################################################\n\n\n";
string salir = "N";
do
{
    Console.Clear();
    Console.WriteLine("Que deceas hacer [Y - salir]?\n\t1 - Generar Reglas\n\t2 - Generar Reglas con querys por un archivo .txt\n\t3 - Generar Reglas ejemplo");
    string op = Console.ReadLine().ToUpper();
    var j = prop.MiLeyPrincipal;
    switch (op)
    {
        case "1":
            generadorDeReglas();
            break;
        case "2":
            Prueba();
            break;
        case "3":
            Prueba2();
            break;
        case "Y":
            salir = "Y";
            break;
        default:

            break;
    }
} while (!salir.Equals("Y"));


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

                        string regla = GerearRegla("",flujoDeRegla, tipoEncabezado, tipoDeFlujoParaCondicion, Arreglo[0], Arreglo[1], Arreglo[2], reglafin, strucparaLeer).Replace("\n", "\n    ");


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
    string tipoEncabezado = archivo.ToUpper();
    
    archivo += ".txt";

    Console.Write("Ingresa la ruta: sonde se leera el .txt:  ");
    string ruta = Console.ReadLine();

    string path = ruta.Replace(@"\\", @"\");
    path += @"\" + archivo;

    try
    {
        StreamReader sr = new StreamReader(@path);
        sr.Close();
    }
    catch (Exception ex)
    {

        Console.WriteLine("No se encontro el archivo \nException:" + ex.Message);
        Console.ReadKey();
        return;
    }

    //Console.Write("Escribe el tipo de flujo para la diferenciar el nombre de la regla  :");
    //string flujoDeRegla = Console.ReadLine();
    //string tipoDeFlujoParaCondicion;//= Console.ReadLine();

    //tipoDeFlujoParaCondicion = flujoDeRegla;

    //Console.Clear();
    //Console.Write("Escribe el nombre para diferenciar encabezado de la regla:");
    //string tipoEncabezado = Console.ReadLine();

    Console.Clear();
    Console.Write("Tipo de flujo \"(Equipos | Interfaces)\"... :");
    string tipoDeFlujoParaCondicion = Console.ReadLine();
    string flujoDeRegla = tipoDeFlujoParaCondicion;

    Console.Write("Nombre del nogocio... :");
    string negocio = Console.ReadLine();

    Console.Clear();
    Console.Write("Tipo de archivo ( YML | DRL)... :");
    string typeArchive = Console.ReadLine().ToUpper();

    string fin = ruta + @"\" + flujoDeRegla + "_" + tipoEncabezado + ".txt";


    try
    {
    Console.Write("Leyendo archivo . . . .");
    Thread.Sleep(1500);
    Console.Clear();

        using (StreamWriter escri = File.CreateText(fin))
        {

            string encabezado = DivisorDeEncavezados.Replace(divEncabezado, tipoEncabezado);

            if (typeArchive.Equals("YML"))
                encabezado= encabezado.Replace("\n", "\n    ");

            escri.WriteLine(encabezado);

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

                if (typeArchive.Equals("YML"))
                    regla = regla.Replace("\n", "\n    ");

                escri.WriteLine(regla);
                Console.Write(". ");
                Thread.Sleep(450);


            }
            escri.WriteLine("\n");
        }

        Console.Write("\n\nArchivo creado con exito . . .\n\r\r\tRUTA DEL ARCHIVO: " + fin);
        Process.Start(new ProcessStartInfo { FileName = @fin, UseShellExecute = true });
        Thread.Sleep(5000);
    }
    catch (Exception ex)
    {
        Console.Clear();
        Console.Write("No se pudo leer/encontrar el archivo: \nMensaje:\t" + ex.Message);
        Console.ReadKey();
        File.Delete(fin);
    }


}

string getTypeSQL(string Query)
{
    int h = Query.IndexOf(" ");
    string SQL = Query.Substring(0, h).ToUpper();


    string ret="";

    if (Const.DML.Contains(SQL))
    {
        ret =nameof(Const.DML);
    }
    else if (Const.DDL.Contains(SQL))
    {
        ret = nameof(Const.DDL);
    }
    else if(Const.SELECT.Contains(SQL))
    {
        ret = nameof(Const.SELECT);
    }
    else
    {
        ret = "SQL";
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

    }
    return queryfinal;

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

    void generadorDeReglas()
    {

        string valorEnrada="N";
        do
        {
        Console.Clear();
            Console.WriteLine("ingresa los Step y SubStep como se muestra en el siguiente ejemplo \"1-1.1|1.2|1.3\" [Y - SALIR]");
            valorEnrada = Console.ReadLine().ToUpper();
            
                try
                {
                    string Step;
                    string[] ArregloSteps;
                    Step = GetStep(valorEnrada);
                    ArregloSteps = GetSubStepsPorPartes(GetSubSteps(valorEnrada));

                    foreach (var item in ArregloSteps)
                    {

                        Console.WriteLine(GerearRegla("", "", "", "", Step, item, "", "", "") + "\n");

                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Intenta de nuevo Error:"+ex.Message);
                    Console.ReadKey();
                    Console.Clear();

                }
            
        } while (valorEnrada != "Y");
    }

    string GerearRegla(string Negocio,string flujoDeRegla, string tipoEncabezado, string tipoDeFlujoParaCondicion, string step, string subStep, string typeSql, string reglafin, string strucparaLeer)
    {
        string regla = "";
        string encambezado = "\n//*********************************************** PASO *step - Sub *subStep - *tipoEncabezado ***********************************************"
        .Replace(reemplazarStep, step).Replace(reemplazarSubStep, subStep).Replace(reemplazarTipoEncabezado, tipoEncabezado);
        regla += encambezado + "\n\n";

        string sub = subStep.Replace('.', '_');
        string inicio = "rule \"*flujoDeRegla-Step*step-SubStep*subStep\"\r\nagenda-group \"*tipoNegocio\""
        .Replace(reemplazarTipoNegocio, Negocio)
        .Replace(reemplazarStep, step)
        .Replace(reemplazarSubStep, sub)
        .Replace(reemplazarFlujoDeRegla, flujoDeRegla);
        regla += inicio + "\n";

        string condicion = "\twhen\r\n\t\tr: HashMap(" + strucparaLeer + "\n\t\t\t\tget(\"type\") == (\"*tipoDeFlujoParaCondicion\") && \r\n\t\t\t\tget(\"step\") == \"*step\" && \r\n\t\t\t\tget(\"subStep\") == \"*subStep\")\r\n\tthen\t"
        .Replace(reemplazarStep, step)
        .Replace(reemplazarSubStep, subStep)
        .Replace(reemplazarTipoDeFlujoParaCondicion, tipoDeFlujoParaCondicion);
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

