using System;
using Tabuleiro_xadrez;
using System.Collections.Generic;

namespace Xadrez
{
    class PartidaDeXadrez
    {
        public Tabuleiro tab { get; private set; } //  a partida tem um tabuleiro //
        public int turno { get; private set; } // cada jogada é um turno //
        public Cor jogadorAtual { get; private set; }// para indicar de quem é a vez de jogar //
        public bool terminada { get; private set; } // para saber quando a partida terminou //
        private HashSet<Peca> pecas; // HashSet é um conjinto. No caso, conjunto de peças. Para mexer com conjuntos, necessário using System.Collection.Generic
        private HashSet<Peca> capturadas;
       
        public PartidaDeXadrez()
        {
            tab = new Tabuleiro(8, 8);
            turno = 1;
            jogadorAtual = Cor.branca;
            terminada = false;
            pecas = new HashSet<Peca>(); // instanciamento dos conjuntos //
            capturadas = new HashSet<Peca>();
            colocarPecas();
        }

        public void executaMovimento(Posicao origem, Posicao destino) // executa movimento tal para posição tal //
        {
            Peca p = tab.retirarPeca(origem); // retirada da peça //
            p.incrementarQteMovimentos();
            Peca pecaCapturada = tab.retirarPeca(destino); // caso haja uma peça na posição de destino, ela será capturada //
            tab.colocarPeca(p, destino);
            if(pecaCapturada != null) // ou seja, se tinha uma peça na posição de destino
            {
                capturadas.Add(pecaCapturada); // se eu capturar uma peça, ela vai para o conjunto de peças capturadas //
            }
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

        public HashSet<Peca> pecasCapturadas(Cor cor) // para peças capturadas, mas separadas por cores
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach(Peca x in capturadas)
            {
                if(x.cor == cor)
                {
                    aux.Add(x);
                }
            }
            return aux;
        }

        public HashSet<Peca> pecasEmJogo(Cor cor) // quais são as peças em jogo de uma dada cor
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca x in pecas)
            {
                if (x.cor == cor)
                {
                    aux.Add(x);
                }
            }
            aux.ExceptWith(pecasCapturadas(cor)); // retiro então as peças capturadas dessa uma cor. Logo vou ter as peças que estão em jogo ainda //
            return aux;
        }

        public void colocarNovaPeca(char coluna, int linha, Peca peca) // dada uma coluna e linha e uma peça:  eu vou no tabuleiro da partida e coloco //
        {
            tab.colocarPeca(peca, new PosicaoXadrez(coluna, linha).toPosicao());
            pecas.Add(peca); // no ocnjunto peças, vou adicionar essa peça
        }

        private void colocarPecas()
        {
            colocarNovaPeca('c', 1, new Torre(tab, Cor.branca)); //entendendo: colocarNovaPeca(char coluna, int linha, Peca peca)
            colocarNovaPeca('c', 2, new Torre(tab, Cor.branca));
            colocarNovaPeca('d', 2, new Torre(tab, Cor.branca));
            colocarNovaPeca('e', 2, new Torre(tab, Cor.branca));
            colocarNovaPeca('e', 1, new Torre(tab, Cor.branca));
            colocarNovaPeca('d', 1, new Rei(tab, Cor.branca));


            colocarNovaPeca('c', 7, new Torre(tab, Cor.preta));
            colocarNovaPeca('c', 8, new Torre(tab, Cor.preta));
            colocarNovaPeca('d', 7, new Torre(tab, Cor.preta));
            colocarNovaPeca('e', 7, new Torre(tab, Cor.preta));
            colocarNovaPeca('e', 8, new Torre(tab, Cor.preta));
            colocarNovaPeca('d', 8, new Rei(tab, Cor.preta));

        }


    }
}
