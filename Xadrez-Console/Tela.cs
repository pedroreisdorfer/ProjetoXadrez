using System;
using Tabuleiro_xadrez;
using Xadrez;
using System.Collections.Generic;

namespace Xadrez_Console
{
    class Tela
    {
        public static void imprimirPartida(PartidaDeXadrez partida) // quando é chamado o método no programa principal, ele realiza tudo aqui abaixo, que são funções que dependem de outras funções, mas que estão todas na classe PartidaDeXdrez //
        {
            imprimirTabuleiro(partida.tab); // a varivável partida chama tab = new Tabuleiro(8, 8);, que está instanciada dentro de PartidaDeXadrez //
            Console.WriteLine();
            imprimirPecasCapturadas(partida); // imprime todo o método imprimir PecasCapturadas, que como é void, irá atualizar a cada jodada, retornando valor para o método mesmo //
            Console.WriteLine();
            Console.WriteLine("Turno: " + partida.turno); // a variável partida chama turno, que é atualizada a cada jogagada. Dentro ds class PartidaDeXadrez tem o método realizadaJogada, que troca de turno após todo o processo //
            Console.WriteLine("Aguardando jogada: " + partida.jogadorAtual);
        }
        

        public static void  imprimirPecasCapturadas(PartidaDeXadrez partida)
        {
            Console.WriteLine("Peças capturadas:");
            Console.Write("Brancas: ");
            imprimirConjunto(partida.pecasCapturadas(Cor.branca)); //a variável partida chama o método pecasCapturadas que está dentro de PartidaDeXadrez, que tem como parâmetro de entrada Cor cor //
            Console.Write("Pretas: ");
            ConsoleColor aux = Console.ForegroundColor; // a cor padrão recebe a ForegroudColor que depois transforma em amarelo //
            Console.ForegroundColor = ConsoleColor.Yellow;
            imprimirConjunto(partida.pecasCapturadas(Cor.preta));
            Console.ForegroundColor = aux; // volta a ser a cor que era //
        }

        public static void imprimirConjunto(HashSet<Peca> conjunto)
        {
            Console.Write("[");
            foreach (Peca x in conjunto)
            {
                Console.Write(x + " ");
            }
            Console.WriteLine("]");
        }
        public static void imprimirTabuleiro(Tabuleiro tab) //void pq imprime e não retorna nenhum valor
                                                            // static usado para que seja usado os métodos dessa classe, sem a necessidade de declarar os objetos dessa classe
                                                            // foi criada uma operação chamada imprimirTabuleiro com entrada tab da classe Tabuleiro
        {
            for (int i = 0; i < tab.linhas; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < tab.colunas; j++)
                {
                    imprimirPeca(tab.peca(i, j));
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }

        public static void imprimirTabuleiro(Tabuleiro tab, bool[,] posicoesPossiveis) 
        {
            ConsoleColor fundoOriginal = Console.BackgroundColor; // pega a cor de fundo //
            ConsoleColor fundoAlterado = ConsoleColor.DarkGray; // ficará cinza escuro quando a posição estiver marcada


            for(int i = 0; i < tab.linhas; i++)
            {
                Console.Write(8 - i + " ");
                for(int j = 0; j < tab.colunas; j++)
                {      
                    if(posicoesPossiveis[i, j]) // se a posição for possível para movimento, eu mudo a cor de fundo //
                    {
                        Console.BackgroundColor = fundoAlterado;
                    }
                    else
                    {
                        Console.BackgroundColor = fundoOriginal;
                    }
                        imprimirPeca(tab.peca(i,j));
                    Console.BackgroundColor = fundoOriginal;
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
            Console.BackgroundColor = fundoOriginal; // faz voltar para  a cor original;
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

            if (peca == null)
            {
                Console.Write("- ");
            }
            else
            {
                if (peca.cor == Cor.branca)
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
                Console.Write(" ");
            }
        }
    }
}
