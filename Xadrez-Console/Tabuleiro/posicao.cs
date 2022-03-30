namespace Tabuleiro_xadrez
{
    class Posicao
    {
        public int linha { get; set; }

        public int coluna { get; set; }

        public Posicao(int linha, int coluna)
        {
            this.linha = linha; // this é a referência do objeto acima chamado linha e outro chamado coluna //
            this.coluna = coluna;           
        }

        public void definirValores(int linha, int coluna)
        {
            this.linha = linha;
            this.coluna = coluna;
        }
        
        public override string ToString()
        {
            return linha
                + ", "
                + coluna;
        }
    }
}
