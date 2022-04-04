using Tabuleiro_xadrez;

namespace Xadrez
{
    class Peao : Peca
    {

        public Peao(Tabuleiro tab, Cor cor) : base(tab, cor)
        {
        }

        public override string ToString()
        {
            return "P";
        }

        private bool podeMover(Posicao pos)
        {
            Peca p = tab.peca(pos);
            return p == null || p.cor != cor;
        }

        public override bool[,] movimentosPossiveis()
        {
            bool[,] mat = new bool[tab.linhas, tab.colunas];

            Posicao pos = new Posicao(0, 0);

            pos.definirValores(posicao.linha - 2, posicao.coluna);
            if (cor == Cor.branca)
            {
                if (tab.posicaoValida(pos) && podeMover(pos) && qteMovimentos == 0)
                {                  
                        mat[pos.linha, pos.coluna] = true;                      
                }
            }

            pos.definirValores(posicao.linha - 1, posicao.coluna);
            if (cor == Cor.branca)
            {
                if (tab.posicaoValida(pos) && podeMover(pos))
                {
                    mat[pos.linha, pos.coluna] = true;
                }
            }


            pos.definirValores(posicao.linha - 1, posicao.coluna + 1);
            if (cor == Cor.branca)
            {
                if (tab.posicaoValida(pos) && podeMover(pos))
                {
                    if (tab.peca(pos) != null && tab.peca(pos).cor != cor)
                    {
                        mat[pos.linha, pos.coluna] = true;
                    }
                }
            }

            pos.definirValores(posicao.linha - 1, posicao.coluna - 1);
            if (cor == Cor.branca)
            {
                if (tab.posicaoValida(pos) && podeMover(pos))
                {
                    if (tab.peca(pos) != null && tab.peca(pos).cor != cor)
                    {
                        mat[pos.linha, pos.coluna] = true;
                    }
                }
            }

            pos.definirValores(posicao.linha + 2, posicao.coluna);
            if (cor == Cor.preta)
            {
                if (tab.posicaoValida(pos) && podeMover(pos) && qteMovimentos == 0)
                {
                    mat[pos.linha, pos.coluna] = true;
                }
            }

            pos.definirValores(posicao.linha + 1, posicao.coluna);
            if (cor == Cor.preta)
            {
                if (tab.posicaoValida(pos) && podeMover(pos))
                {
                    mat[pos.linha, pos.coluna] = true;
                }
            }

            pos.definirValores(posicao.linha + 1, posicao.coluna - 1);
            if (cor == Cor.preta)
            {
                if (tab.posicaoValida(pos) && podeMover(pos))
                {
                    if (tab.peca(pos) != null && tab.peca(pos).cor != cor)
                    {
                        mat[pos.linha, pos.coluna] = true;
                    }
                }
            }

            pos.definirValores(posicao.linha + 1, posicao.coluna + 1);
            if (cor == Cor.preta)
            {
                if (tab.posicaoValida(pos) && podeMover(pos))
                {
                    if (tab.peca(pos) != null && tab.peca(pos).cor != cor)
                    {
                        mat[pos.linha, pos.coluna] = true;
                    }
                }
            }

            return mat;
        }
    }
}
