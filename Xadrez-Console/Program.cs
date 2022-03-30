using System;
using Tabuleiro_xadrez;
using Xadrez_Console;
using Xadrez;

namespace xadrez_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Tabuleiro tab = new Tabuleiro(8, 8);

            tab.colocarPeca(new Torre(tab, Cor.preta), new Posicao(0, 0));
            tab.colocarPeca(new Torre(tab, Cor.preta), new Posicao(1, 3));
            tab.colocarPeca(new Rei(tab, Cor.preta), new Posicao(2, 4));

            Tela.imprimirTabuleiro(tab);

            Console.ReadLine();

            //Tabuleiro tab = new Tabuleiro(8, 8);
        }
    }
}
