using System;
using Tabuleiro_xadrez;

namespace Xadrez
{
    class PartidaDeXadrez
    {
        public Tabuleiro tab { get; private set; } //  a partida tem um tabuleiro //
        public int turno { get; private set; } // cada jogada é um turno //
        public Cor jogadorAtual { get; private set; }// para indicar de quem é a vez de jogar //
        public bool terminada { get; private set; } // para saber quando a partida terminou //
        public PartidaDeXadrez()
        {
            tab = new Tabuleiro(8, 8);
            turno = 1;
            jogadorAtual = Cor.branca;
            terminada = false;
            colocarPecas();
        }

        public void executaMovimento(Posicao origem, Posicao destino) // executa movimento tal para posição tal //
        {
            Peca p = tab.retirarPeca(origem); // retirada da peça //
            p.incrementarQteMovimentos();
            Peca pecaCapturada = tab.retirarPeca(destino); // caso haja uma peça na posição de destino, ela será capturada //
            tab.colocarPeca(p, destino);
        }

        public void realizaJogada(Posicao origem, Posicao destino) // para funcionalidade do turno
        {
            executaMovimento(origem, destino);
            turno++; // passa para o próximo turno //
            mudaJogador(); // após troca de turno, muda o jogador que irá jogar //
        }

        //teste se a posição é válida. Se vc vai digitar na origem uma posição que tem peça //
        public void validarPosicaoDeOrigem(Posicao pos)
        {
            if(tab.peca(pos) == null) // a posição que vc digitar é um lugar no tabuleiro. Se for null, signifa que não tem peça, logo, não pode ser origem //
            {
                throw new TabuleiroException("Não existe peça na posição de origem escolhida!");
            }
            if(jogadorAtual != tab.peca(pos).cor) // eu só posso escolher uma peça da cor da peça do jogador atual //
            {
                throw new TabuleiroException("A peça de origem escolhida não é sua!");
            }
            if (!tab.peca(pos).existeMovimentosPossiveis()) // !=não, se não existe movimentos possíveis para essa peça, então... //
            {
                throw new TabuleiroException("Não há movimentos possíveis para a peça de origem escolhida!");
            }
        }

        public void validarPosicaoDestino(Posicao origem, Posicao destino)
        {
            if (!tab.peca(origem).podeMoverPara(destino)) // se a peça de origem NÃO pode mover para a posição de destino
            {
                throw new TabuleiroException("Posição de destino inválida!");
            }
        }

        private void mudaJogador()
        {
            if (jogadorAtual == Cor.branca){
                jogadorAtual = Cor.preta; // no caso, se for jogador das brancas que fez a jogada, troca para jogador das pretas //
            }
            else
            {
                jogadorAtual = Cor.branca;
            }
        }

        private void colocarPecas()
        {
            tab.colocarPeca(new Torre(tab, Cor.branca), new PosicaoXadrez('c', 1).toPosicao());
            tab.colocarPeca(new Torre(tab, Cor.branca), new PosicaoXadrez('c', 2).toPosicao());
            tab.colocarPeca(new Torre(tab, Cor.branca), new PosicaoXadrez('d', 2).toPosicao());
            tab.colocarPeca(new Torre(tab, Cor.branca), new PosicaoXadrez('e', 2).toPosicao());
            tab.colocarPeca(new Torre(tab, Cor.branca), new PosicaoXadrez('e', 1).toPosicao());
            tab.colocarPeca(new Rei(tab, Cor.branca), new PosicaoXadrez('d', 1).toPosicao());

            tab.colocarPeca(new Torre(tab, Cor.preta), new PosicaoXadrez('c', 7).toPosicao());
            tab.colocarPeca(new Torre(tab, Cor.preta), new PosicaoXadrez('c', 8).toPosicao());
            tab.colocarPeca(new Torre(tab, Cor.preta), new PosicaoXadrez('d', 7).toPosicao());
            tab.colocarPeca(new Torre(tab, Cor.preta), new PosicaoXadrez('e', 7).toPosicao());
            tab.colocarPeca(new Torre(tab, Cor.preta), new PosicaoXadrez('e', 8).toPosicao());
            tab.colocarPeca(new Rei(tab, Cor.preta), new PosicaoXadrez('d', 8).toPosicao());

        }


    }
}
