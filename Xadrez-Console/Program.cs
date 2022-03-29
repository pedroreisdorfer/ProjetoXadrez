using System;
using Tabuleiro_xadrez;
using Xadrez_Console;

namespace xadrez_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Tabuleiro tab = new Tabuleiro(8, 8);

            Tela.imprimirTabuleiro(tab);

            Console.ReadLine();

            //Tabuleiro tab = new Tabuleiro(8, 8);
        }
    }
}
