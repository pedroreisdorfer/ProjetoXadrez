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

        private bool podeMover(Posicao pos) // para verificar se o rei pode mover para uma determinada posição //
        {
            Peca p = tab.peca(pos); // pega peça que está na posição pos //
            return p == null || p.cor != cor; // pode mover ou quando a cada está livre OU quando é uma peça adversária
        }

        public override bool[,] movimentosPossiveis()
        {
            bool[,] mat = new bool[tab.linhas, tab.colunas]; //instanciando matriz temporária

            Posicao pos = new Posicao(0, 0);

            // a seguir as possíveis movimentações que o rei pode fazer //
            // acima
            pos.definirValores(posicao.linha - 1, posicao.coluna); //pq a linha 8 é posição 0 e a linha 1 é a posição 7 //
            if(tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            // nordeste
            pos.definirValores(posicao.linha - 1, posicao.coluna + 1); 
            if (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            // direita
            pos.definirValores(posicao.linha, posicao.coluna + 1); 
            if (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            // sudeste
            pos.definirValores(posicao.linha + 1, posicao.coluna + 1); 
            if (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            // abaixo
            pos.definirValores(posicao.linha + 1, posicao.coluna); 
            if (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            // sudoeste
            pos.definirValores(posicao.linha + 1, posicao.coluna - 1); 
            if (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            // esquerda
            pos.definirValores(posicao.linha, posicao.coluna - 1); 
            if (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            // noroeste
            pos.definirValores(posicao.linha - 1, posicao.coluna - 1); 
            if (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }
            return mat;
        } 
        
    }
}
