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

        public void colocarPeca(Peca p, Posicao pos)
        {
            pecas[pos.linha, pos.coluna] = p; // a Peca p vai para a posição pos.linha, pos.coluna]
            p.posicao = pos;    
        }
    }
}
