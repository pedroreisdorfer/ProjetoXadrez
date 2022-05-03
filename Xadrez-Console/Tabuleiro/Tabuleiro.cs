using Xadrez;

namespace Tabuleiro_xadrez
{
    class Tabuleiro
    {
        public int linhas { get; set; }

        public int colunas { get; set; }

        private Peca[,] pecas; // bloqueado o acesso direto a matriz //

        public Tabuleiro(int linhas, int colunas)
        {
            this.linhas = linhas;
            this.colunas = colunas;
            pecas = new Peca[linhas, colunas];
        }
        
        public Peca peca(int linha, int coluna) // através desse método, é possível ter acesso individual a cada peça do tabuleiro //
        {
            return pecas[linha, coluna]; // retorna os atributos na posição linha e posição coluna //
        }

        public Peca peca(Posicao pos) 
        {
            return pecas[pos.linha, pos.coluna]; 
        }

        public bool existePeca(Posicao pos) // se existe peça em uma determinada posição //
        {
            validarPosicao(pos);
            return peca(pos) != null; // se é diferente de null é pq tem peça.Porém, pode ser que a posição seja inváçida, por isso precisa ser validado antes. Caso a posição seja inválida, cursor pula para a exception //
        }

        public void colocarPeca(Peca p, Posicao pos)
        {
            if (existePeca(pos)) // assim eu só posso colocar peça onde não tem peça //
            {
                throw new TabuleiroException("Já existe uma peça nessa posição!");
            }
            pecas[pos.linha, pos.coluna] = p; // a Peca p vai para a posição pos.linha, pos.coluna]
            p.posicao = pos;    
        }

        // método para retirar peça. Já que a mesmo pode ser retornada, não pode ser void //
        public Peca retirarPeca(Posicao pos)
        {
            if(peca(pos) == null) //uma peça na posição pos sendo nula, significa que não tem nenhuma peça, logo, nada para ser retirado //
            {
                return null;
            }
            Peca aux = peca(pos); // recebe a peça que está na posição informada. Agora a variável aux é a peça em determinada posição //
            aux.posicao = null; // peça foi retirada da sua posição. Neste caso, a peça estava numa posição que agora passa a ser nula, ou seja, sem nada nela //
            pecas[pos.linha, pos.coluna] = null; // a posição na matriz passa a ser nula //
            return aux; // retorna como peça retirada //
        }
        public bool posicaoValida(Posicao pos) // testando se a posição é valida, pois já que são 8 linhas e 8 colunas, as posições vão de 0 a 7.
        {
            if(pos.linha < 0 || pos.linha >= linhas || pos.coluna < 0 || pos.coluna >= colunas)
            {
                return false;
            }
            return true;
        }

        public void validarPosicao(Posicao pos) // criado para: caso a posição não seja válida irá lançar uma exceção personalizada //
        {
            if (!posicaoValida(pos)) // significa: se minha posição pos não for válida, ai lanço uma exceção //
            {
                throw new TabuleiroException("Posição inválida!");
            }
        }

        

    }
}
