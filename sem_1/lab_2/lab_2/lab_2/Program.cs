using Data;
using lab_2.Data.Classes;
using System;
using System.Diagnostics.Tracing;

namespace lab_1
{
    internal class Program
    { 
        static void Main(string[] args)
        {
            Mom mom = new Mom("12");
            mom.Cook();
            Console.ReadKey();
        }
    }
}