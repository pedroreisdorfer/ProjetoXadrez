namespace Tabuleiro_xadrez
{
    abstract class Peca // já que tem método abstrato, a classe passa a ser um método abstrato //
    {
        public Posicao posicao { get; set; }
        public Cor cor { get; protected set; }
        public int qteMovimentos { get; protected set; }
        public Tabuleiro tab { get; protected set; }

        //contrutores

        public Peca(Tabuleiro tab, Cor cor)
        {
            this.posicao = null;
            this.tab = tab;
            this.cor = cor;        
            this.qteMovimentos = 0; // começa zero pois a peça inicialmente é parada //
        }

        public void incrementarQteMovimentos() // operação simples que vai somando cada movimento //
        {
            qteMovimentos++;
        }

        public abstract bool[,] movimentosPossiveis(); // matriz boleana, pq para onde a peça movimentar será True e False para as outras opções.
                                                       // O método precisa ser abstrato, pois ele vai ser chamado em cada classe de peça específica para que
                                                       // haja o movimento. A regra de movimentos é prevista para cada peça específica //

    }
}
