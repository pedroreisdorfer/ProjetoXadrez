using Tabuleiro_xadrez;

namespace Xadrez
{
    class Torre : Peca
    {
        // construtor //
        public Torre(Tabuleiro tab, Cor cor) : base(tab, cor) 
                                                            
        {
        }

        public override string ToString()
        {
            return "T";
        }

        private bool podeMover(Posicao pos) // para verificar se a torre pode mover para uma determinada posição //
        {
            Peca p = tab.peca(pos); // pega peça que está na posição pos //
            return p == null || p.cor != cor; // pode mover ou quando a cada está livre OU quando é uma peça adversária
        }

        public override bool[,] movimentosPossiveis()
        {
            bool[,] mat = new bool[tab.linhas, tab.colunas]; //instanciando matriz temporária

            Posicao pos = new Posicao(0, 0);

            // a seguir as possíveis movimentações que a torre pode fazer //

            // acima
            pos.definirValores(posicao.linha - 1, posicao.coluna); //pq a linha 8 é posição 0 e a linha 1 é a posição 7 //
            while (tab.posicaoValida(pos) && podeMover(pos)) // enquanto estir livre e a posição for válida, posso mover //
            {
                mat[pos.linha, pos.coluna] = true;

                if(tab.peca(pos) != null && tab.peca(pos).cor != cor) // só paro quando bater numa posição com peça e tal peça seja da cor adversária // 
                {
                    break; // forço a parada //
                }
                pos.linha = pos.linha - 1;
            }


            // abaixo
            pos.definirValores(posicao.linha + 1, posicao.coluna); //pq a linha 8 é posição 0 e a linha 1 é a posição 7 //
            while (tab.posicaoValida(pos) && podeMover(pos)) // enquanto estir livre e a posição for válida, posso mover //
            {
                mat[pos.linha, pos.coluna] = true;

                if (tab.peca(pos) != null && tab.peca(pos).cor != cor) // só paro quando bater numa posição com peça e tal peça seja da cor adversária // 
                {
                    break; // forço a parada //
                }
                pos.linha = pos.linha + 1;
            }

            // direita
            pos.definirValores(posicao.linha, posicao.coluna + 1); //pq a linha 8 é posição 0 e a linha 1 é a posição 7 //
            while (tab.posicaoValida(pos) && podeMover(pos)) // enquanto estir livre e a posição for válida, posso mover //
            {
                mat[pos.linha, pos.coluna] = true;

                if (tab.peca(pos) != null && tab.peca(pos).cor != cor) // só paro quando bater numa posição com peça e tal peça seja da cor adversária // 
                {
                    break; // forço a parada //
                }
                pos.coluna = pos.coluna + 1;
            }


            // esquerda
            pos.definirValores(posicao.linha, posicao.coluna - 1); //pq a linha 8 é posição 0 e a linha 1 é a posição 7 //
            while (tab.posicaoValida(pos) && podeMover(pos)) // enquanto estir livre e a posição for válida, posso mover //
            {
                mat[pos.linha, pos.coluna] = true;

                if (tab.peca(pos) != null && tab.peca(pos).cor != cor) // só paro quando bater numa posição com peça e tal peça seja da cor adversária // 
                {
                    break; // forço a parada //
                }
                pos.coluna = pos.coluna - 1;
            }

            return mat;
        }




    }
}
