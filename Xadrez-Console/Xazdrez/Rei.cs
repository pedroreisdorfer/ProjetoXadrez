using Tabuleiro_xadrez;

namespace Xadrez
{
    class Rei : Peca
    {
        private PartidaDeXadrez partida; // para que o rei tenha acesso a partida. Para operação do roque //
        
        // construtor //
        public Rei(Tabuleiro tab, Cor cor, PartidaDeXadrez partida) : base(tab, cor) // construtor de um rei recebe Tabuleiro tab e Cor cor.
                                                                                    // E repassa tal instrução para a classe Peca com :base(tab, cor), pois a class Rei herda da class Peca //
        {
            this.partida = partida; // agora está completo o acesso a partida //
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

        public bool testeTorreParaRoque(Posicao pos)
        {
            Peca p = tab.peca(pos);
            return p != null && p is Torre && p.cor == cor && p.qteMovimentos == 0;
            // se tiver alguma peça nessa posição, se for uma torre, cor igual do rei e não tiver sido movimentada //
        }

        public override bool[,] movimentosPossiveis()
        {
            bool[,] mat = new bool[tab.linhas, tab.colunas]; //instanciando matriz temporária

            Posicao pos = new Posicao(0, 0);

            // a seguir as possíveis movimentações que o rei pode fazer //
            // acima
            pos.definirValores(posicao.linha - 1, posicao.coluna); //pq a linha 8 é posição 0 e a linha 1 é a posição 7 //
            if (tab.posicaoValida(pos) && podeMover(pos))
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

            //#jogada especial roque  
            if (qteMovimentos == 0 && !partida.xeque) // se o rei não fez nenhum movimento e não está em xeque
            {
                // roque pequeno
                Posicao posT1 = new Posicao(posicao.linha, posicao.coluna + 3); // verificação da posição da torre
                if (testeTorreParaRoque(posT1))
                {
                    Posicao p1 = new Posicao(posicao.linha, posicao.coluna + 1); // no caso é a cada do lado onde o rei está
                    Posicao p2 = new Posicao(posicao.linha, posicao.coluna + 2);
                    if (tab.peca(p1) ==null && tab.peca(p2) == null) // então caso não tiver nenhum peça nas duas casas ao lado do rei
                    {
                        mat[posicao.linha, posicao.coluna + 2] = true; //pode mover então para essa casa
                    }
                }

                // roque grande
                Posicao posT2 = new Posicao(posicao.linha, posicao.coluna - 4); // verificação da posição da torre
                if (testeTorreParaRoque(posT2))
                {
                    Posicao p1 = new Posicao(posicao.linha, posicao.coluna - 1); // no caso é a cada do lado onde o rei está
                    Posicao p2 = new Posicao(posicao.linha, posicao.coluna - 2);
                    Posicao p3 = new Posicao(posicao.linha, posicao.coluna - 3);
                    if (tab.peca(p1) == null && tab.peca(p2) == null && tab.peca(p3) == null) // então caso não tiver nenhum peça nessas posições
                    {
                        mat[posicao.linha, posicao.coluna - 2] = true; //pode mover então para essa casa
                    }
                }
            }
            
            return mat;
        }

    }
}
