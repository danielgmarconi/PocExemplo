﻿using System;
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

            JsonMessage.Obter("mensagem.json", 1, "V");
            Console.ReadLine();
        }
    }
}
