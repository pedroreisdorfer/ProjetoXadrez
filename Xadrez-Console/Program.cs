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
            try
            {
                Tabuleiro tab = new Tabuleiro(8, 8);

                tab.colocarPeca(new Torre(tab, Cor.preta), new Posicao(0, 0));
                tab.colocarPeca(new Torre(tab, Cor.preta), new Posicao(1, 9));
                tab.colocarPeca(new Rei(tab, Cor.preta), new Posicao(0, 5));

                Tela.imprimirTabuleiro(tab);              

                //Tabuleiro tab = new Tabuleiro(8, 8);
            }
            catch(TabuleiroException e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }
    }
}
