using System;
using System.Linq;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;

namespace DemoJson
{
    class Program
    {
        static void Main(string[] args)
        {
            Pessoa busca = new Pessoa();
            JsonParseClass jpc = new JsonParseClass();
            Console.WriteLine(DateTime.Now.ToString("dd/MM/yyyy hh:mm:sss"));
            busca.id = 1;
            List<Pessoa> lista = jpc.FileJsonParse<Pessoa>("JsonTeste.json", busca);
            Console.WriteLine("ID: " + lista[0].id + " Nome: " + lista[0].nome);
            Console.WriteLine(DateTime.Now.ToString("dd/MM/yyyy hh:mm:sss"));
            Console.WriteLine("");
            Console.WriteLine(DateTime.Now.ToString("dd/MM/yyyy hh:mm:sss"));
            busca.id = null;
            busca.nome = "Cicl";
            lista = jpc.FileJsonParse<Pessoa>("JsonTeste.json", busca);
            Console.WriteLine("ID: " + lista[0].id + " Nome: " + lista[0].nome);
            Console.WriteLine(DateTime.Now.ToString("dd/MM/yyyy hh:mm:sss"));
            Console.WriteLine("");
            Console.WriteLine(DateTime.Now.ToString("dd/MM/yyyy hh:mm:sss"));
            busca.id = 3;
            busca.nome = null;
            lista = jpc.FileJsonParse<Pessoa>("JsonTeste.json", busca);
            Console.WriteLine("ID: " + lista[0].id + " Nome: " + lista[0].nome);
            Console.WriteLine(DateTime.Now.ToString("dd/MM/yyyy hh:mm:sss"));
            Console.ReadLine();
        }
    }
}
