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
                tab.colocarPeca(new Torre(tab, Cor.preta), new Posicao(1, 3));
                tab.colocarPeca(new Rei(tab, Cor.preta), new Posicao(0, 2));

                tab.colocarPeca(new Torre(tab, Cor.branca), new Posicao(3, 5));

                Tela.imprimirTabuleiro(tab);              

            }
            catch(TabuleiroException e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }
    }
}
