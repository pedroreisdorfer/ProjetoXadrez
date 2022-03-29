using System;
using Tabuleiro_xadrez;

namespace Xadrez_Console
{
    class Tela
    {
        public static void imprimirTabuleiro(Tabuleiro tab) //void pq imprimi e não retorna nenhum valor
        {
            for(int i = 0; i < tab.linhas; i++)
            {
                for(int j = 0; j < tab.colunas; j++)
                {
                    if(tab.peca(i,j) == null)
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                        Console.Write(tab.peca(i,j) + " "); // se chama o método peca do obejto tab //
                    }
                    

                }
                Console.WriteLine();
            }
        }
    }
}
