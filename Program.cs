//constantes para reemplazar
using GeneradorReglasDrools;
using System.Diagnostics;
using System;
using System.Configuration;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

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
    try
    {
         
        Console.Clear();
        Console.WriteLine("Que deceas hacer [Y - salir]?\n\t1 - Generar reglas de archivo formateado\n\t" +
            "2 - Generar formato\n\t3 - Generar formato y reglas\n\t4 - Generar KPIS (NO dinamico)\n\t5 - Generar cascaron de reglas");
        string op = Console.ReadLine().ToUpper();

        switch (op)
        {
            case "1":
                Prueba();
                break;
            case "2":
                getFormatTxt();
                break;
            case "3":
                GenerarAll();
                break;
            case "4":
                KPISQuery();
                break;
            case "5":
                generadorDeReglas();
                break;
            case "Y":
                salir = "Y";
                Console.Clear();
                Console.WriteLine("Adios .... ");
                Console.ReadKey();
                break;
            default:

                break;
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine("Error ->\t" + ex.Message);
        Console.ReadKey();
    }
} while (!salir.Equals("Y"));

void GenerarAll()
{
    Prueba(getFormatTxt());
}

void KPISQuery()
{
    Console.WriteLine("Ingresa el rango  de steps - [0-2]: ");
    string num = Console.ReadLine();
    try
    {
        for (int i = int.Parse(GetStep(num)); i < int.Parse(GetSubSteps(num)); i++)
            Console.WriteLine( GetKPISQuery(i));
        
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
        Console.ReadKey();

}


void Prueba(string? rut="")
{
    Console.Clear();
    string path = "";
    string ruta = "";
    string tipoEncabezado = "";
    if (string.IsNullOrEmpty(rut))
    {
        Console.Write("Ingresa la ruta y nombre del archivo \"C:\\drools\\5 minutos.txt\":  ");
        ruta = Console.ReadLine();
        path = ruta.Replace(@"\\", @"\");
    }
    else
    {
        path = rut;
    }

        ruta = Splitphat(path,rut)[0]; 
        tipoEncabezado = Splitphat(path,rut)[1]; 

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
    Console.Clear();
    Console.Write("Nombre de flujo: ");// \"(Equipos | Interfaces)\"...
    string tipoDeFlujoParaCondicion = Console.ReadLine();
    string flujoDeRegla = tipoDeFlujoParaCondicion;

    Console.Write("Nombre de nogocio: ");
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
                try
                {
                    string[] Arreglo = GetSubStepsPorPartes(line);

                    if (line.Contains("--"))
                    {
                        //break;
                        throw new InvalidOperationException(string.Format("hay comentarios en el paso {0}-{1}... favor de eliminarlos", Arreglo[0], Arreglo[1]));
                    }

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

                    string regla = GerearRegla(negocio, flujoDeRegla, tipoEncabezado, tipoDeFlujoParaCondicion, Arreglo[0], Arreglo[1], typeSQL, reglafin, strucparaLeer);

                    if (typeArchive.Equals("YML"))
                        regla = regla.Replace("\n", "\n    ");

                    escri.WriteLine(regla);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("\nError -> "+ex.Message);
                }
                finally
                {

                    Console.Write(". ");
                    Thread.Sleep(450);
                }


            }
            escri.WriteLine("\n");
        }

        Console.Write("\nArchivo creado con exito . . .\n\tRUTA DEL ARCHIVO: " + fin);
        Console.ReadKey();
        Process.Start(new ProcessStartInfo { FileName = @fin, UseShellExecute = true });
        Thread.Sleep(500);
    }
    catch (Exception ex)
    {
        Console.Clear();
        Console.Write("Error:\t->:  " + ex.Message);
        Console.ReadKey();
        File.Delete(fin);
    }


}

string[] Splitphat(string path, string? rut)
{
    string[] splits = path.Split("\\");
    string nomAr = splits[splits.Length - 1];
    string[] split= {
    path.Substring(0, (path.Length - (nomAr.Length + 1))),
    string.IsNullOrWhiteSpace(rut) ? nomAr.Split(".")[0] : nomAr.Split(".")[0].Split("_")[1]};

    return split;
}

string getTypeSQL(string Query)
{
    string SQL = Query.Substring(0, Query.IndexOf(" ")).ToUpper();

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
            //string remplazo = parametro.Contains("fecha")? string.Format("'\" + ${0} + \"'", parametro.Substring(1)): string.Format("\" + ${0} + \"", parametro.Substring(1));
            string remplazo = Const.parametrosFecha.Contains(parametro) ? string.Format("'\" + ${0} + \"'", parametro.Substring(1)): string.Format("\" + ${0} + \"", parametro.Substring(1));

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
        string remplace = Const.parametrosFecha.Contains(k) ? string.Format("'\" + ${0} + \"'", k.Substring(1)): string.Format("\" + ${0} + \"", k.Substring(1));
                
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
            //string typeRempl = k.Contains("fecha")? reemplazoDeFecha:reemplazoDeDatoNormal;
            string typeRempl = Const.parametrosFecha.Contains(k) ? reemplazoDeFecha:reemplazoDeDatoNormal;

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
        
        string typeRem = Const.parametrosFecha.Contains(n) ? reemplazoDeFecha : reemplazoDeDatoNormal;

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


    int[] valores = new int[Const.endParam.Length]; 

    for (int i = 0; i < Const.endParam.Length; i++)
        valores[i] = g.IndexOf(Const.endParam[i]);
    

    List<string> param= new List<string>();

    foreach (var item in valores)
    {
        if (item >= 0)
            param.Add(queryentrante.Substring(prim, item));
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
        Console.WriteLine("=> NO HAY PARAMETRO ESTABLECIDO EN LAS CONSTANTES [ |{0}|-|{1}| ] <=", string.Join(",", param),g);

    return parametrofinal;
}

    void generadorDeReglas()
{

    string valorEnrada = "N";
    do
    {
        Console.Clear();
        Console.WriteLine("ingresa los Step y SubStep como se muestra en el siguiente ejemplo \"1-1.1|1.2|1.3\" [Y - SALIR]");
        valorEnrada = Console.ReadLine().ToUpper();

        try
        {
            if (valorEnrada.Equals("Y")) return;

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
            Console.WriteLine("Intenta de nuevo Error:" + ex.Message);

        }
            Console.ReadKey();
            Console.Clear();

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

    string GetKPISQuery(int num)
{
    string jc = "\r\n    //*********************************************** Potencia-KPIS-CALIDAD_RED-TYPE: 1 - Executed: <num> - Cod:000  - POTENCIA ***********************************************\r\n\r\n    rule \"Potencia-KPIS-CALIDAD_RED-type1Ex<num>\"\r\n    agenda-group \"KPIS\"\r\n        when\r\n            r: HashMap(\tget(\"client\") == (\"CALIDAD_RED\") && \r\n                        get(\"flow\") == \"potencia\" && \r\n                        get(\"type\") == \"1\" ) &&\r\n                        get(\"executedStep\") == \"<num>\" &&\r\n                        get(\"ack_code\") == \"000\")\r\n        then\t\t\r\n        \r\n        // Definiendo salida \r\n        \r\n        outParams.put(\"client\", \"CALIDAD_RED\");\r\n        outParams.put(\"steps\", getParam(\"<numP>\",\"<numP>.1|<numP>.2\"));\t\r\n        outParams.put(\"flow\", \"potencia\");\r\n        end\r\n\r\n    //*****************************************************************************************************************************\r\n";
    jc = jc.Replace("<num>", num.ToString());
    jc = jc.Replace("<numP>", (num+1).ToString());
    return jc;
}

string getFormatTxt()
{
    Console.Clear();
    string ruta;
    string tipoEncabezado;
    Console.Write("Ingresa la ruta y nombre del archivo \"C:\\drools\\5 minutos.txt\":  ");

    ruta = Console.ReadLine();
    string path = ruta.Replace(@"\\", @"\");

    ruta = Splitphat(path, "")[0];
    tipoEncabezado = Splitphat(path, "")[1];

    try
    {
        StreamReader sr = new StreamReader(@path);
        sr.Close();
    }
    catch (Exception ex)
    {

        Console.WriteLine("No se encontro el archivo \nException:" + ex.Message);
        Console.ReadKey();
        return "";
    }

    string fin = ruta + @"\" + "format" + "_" + tipoEncabezado + ".txt";


    try
    {
        Console.Write("Leyendo archivo . . . .");
        Thread.Sleep(1500);
        Console.Clear();
        string All = "";

        using (StreamWriter escri = File.CreateText(fin))
        {
            Console.Write("Creando archivo ...\n");
            Thread.Sleep(1000);
            int file = 0;

            foreach (string line in System.IO.File.ReadLines(@path))
            {
                All += line.Replace("\n", " ") + " ";
                file++;
                Console.Write(". ");
                Thread.Sleep(10);
            }
            Console.Clear();
            Console.Write("Formateando ...\n");
            for (int i = 1; i < file; i++)
            {
                string b = string.Format("{0}\t{1}.", i, i);
                All = All.Replace(b, string.Format("\n{0}|{1}.", i, i));
                Console.Write(". ");
                Thread.Sleep(10);
            }
            All = All.Replace("\t", "|").Replace("\"", "");

            escri.WriteLine(All);
            escri.Close();
        }

        Console.Write("\n\nArchivo creado con exito . . .\n\r\r\tRUTA DEL ARCHIVO: " + fin);
        Console.ReadKey();
        Process.Start(new ProcessStartInfo { FileName = @fin, UseShellExecute = true });
        Thread.Sleep(500);
    }
    catch (Exception ex)
    {
        Console.Clear();
        Console.Write("Error:\t->:  " + ex.Message);
        Console.ReadKey();
        File.Delete(fin);
    }

    return fin;


}