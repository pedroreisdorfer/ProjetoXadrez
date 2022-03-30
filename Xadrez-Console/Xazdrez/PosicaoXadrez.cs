using System;
using Tabuleiro_xadrez;

namespace Xadrez
{
    class PosicaoXadrez
    {
        // criada essa classe, pois a posição no xadrez é feita por letra + o número da linha. As letras ficam em colunas //
        public char coluna { get; set; }
        public int linha { get; set; }

        public PosicaoXadrez(char coluna, int linha)
        {
            this.coluna = coluna;
            this.linha = linha;
        }

        public Posicao toPosicao()
        {
            return new Posicao(8 - linha, coluna - 'a'); // se a pessoa digitar e7, 8-7=1. A letra e é igual ao número 5 e a é 1. Logo, 5-1=4. Posição na matriz fica(1,4) //
        }

        public override string ToString()
        {
            return "" + coluna + linha;
        }
    }
}
