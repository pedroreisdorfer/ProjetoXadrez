using Tabuleiro_xadrez;

namespace Xadrez
{
    class Rei : Peca
    {
        // construtor //
        public Rei(Tabuleiro tab, Cor cor) : base(tab, cor) // construtor de um rei recebe Tabuleiro tab e Cor cor.
                                                            // E repassa tal instrução para a classe Peca com :base(tab, cor), pois a class Rei herda da class Peca //
        {
        }

        public override string ToString()
        {
            return "R";
        }
    }
}
