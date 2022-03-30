using System;
using Tabuleiro_xadrez;
using Xadrez;

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
                Console.Write(8 - i + " ");
                for(int j = 0; j < tab.colunas; j++)
                {
                    if(tab.peca(i,j) == null) // quando se instancia uma matriz é jogado null em todas as posições. Logo, se não tiver nenhuma peça na posição, será preenchido com "- " //
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                        imprimirPeca(tab.peca(i,j));
                        Console.Write(" ");
                    }                  
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }

        public static PosicaoXadrez lerposicaoXadrez()
        {
            string s = Console.ReadLine();
            char coluna = s[0];
            int linha = int.Parse(s[1] + ""); // as aspas força a isso ser um string //
            return new PosicaoXadrez(coluna, linha);
        }

        public static void imprimirPeca(Peca peca)
        {
            if(peca.cor == Cor.branca)
            {
                Console.Write(peca);
            }
            else
            {
                ConsoleColor aux = Console.ForegroundColor; // ForegroundColor é a cor padrão impressa pelo programa // 
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(peca);
                Console.ForegroundColor = aux;
            }
        }
    }
}
