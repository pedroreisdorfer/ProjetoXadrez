using System;
using Tabuleiro_xadrez;

namespace Xadrez_Console
{
    class Tela
    {
        public static void imprimirTabuleiro(Tabuleiro tab) //void pq imprime e não retorna nenhum valor
            // static usado para que seja usado os métodos dessa classe, sem a necessidade de declarar os objetos dessa classe
            // foi criada uma operação chamada imprimirTabuleiro com entrada tab da classe Tabuleiro
        {

            for(int i = 0; i < tab.linhas; i++)
            {
                for(int j = 0; j < tab.colunas; j++)
                {
                    if(tab.peca(i,j) == null) // quando se instancia uma matriz é jogado null em todas as posições. Logo, se não tiver nenhuma peça na posição, será preenchido com "- " //
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
