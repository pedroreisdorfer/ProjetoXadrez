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
                PartidaDeXadrez partida = new PartidaDeXadrez();               

                while (!partida.terminada)
                {
                    try
                    {
                        Console.Clear();
                        Tela.imprimirPartida(partida);
                        Console.WriteLine();
                        Console.Write("Origem: ");
                        Posicao origem = Tela.lerposicaoXadrez().toPosicao(); //le a posição e transforma ela em posição de matriz com toPosicao() //
                        partida.validarPosicaoDeOrigem(origem);

                        bool[,] posicoesPossiveis = partida.tab.peca(origem).movimentosPossiveis(); // a partir da posição de origem que o funcionário digitou, eu vou acessar essa peça de origem e pegar os movimentos possíveis dela, guardando na matriz posicoesPossiveis //

                        Console.Clear();
                        Tela.imprimirTabuleiro(partida.tab, posicoesPossiveis);

                        Console.WriteLine();
                        Console.Write("Destino: ");
                        Posicao destino = Tela.lerposicaoXadrez().toPosicao();
                        partida.validarPosicaoDestino(origem, destino);
                        
                        partida.realizaJogada(origem, destino); // após essa parte o turno é troca e ocorre mudan~ça de jogador
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }
                }            

            }
            catch(TabuleiroException e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }
    }
}
