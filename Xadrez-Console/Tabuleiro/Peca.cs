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
        public void decrementarQteMovimentos() // retira unidade dessa quantidade //
        {
            qteMovimentos--;
        }
        public bool existeMovimentosPossiveis() // vê se na matriz de movimentosPossiveis(), existe algum movimento true. Teste se a peça não está bloqueada de movimentos
        {
            bool[,] Mat = movimentosPossiveis();
            for (int i=0; i<tab.linhas; i++)
            {
                for(int j=0; j<tab.colunas; j++)
                {
                    if (Mat[i, j])
                    {
                        return true;
                    }
                }
            }
            return false; // quer dizer que não tem nenhum movimento possível na matriz de movimentos possíveis //          
        }

        public bool podeMoverPara(Posicao pos)
        {
            return movimentosPossiveis()[pos.linha, pos.coluna];
        }

        public abstract bool[,] movimentosPossiveis(); // matriz boleana, pq para onde a peça movimentar será True e False para as outras opções.
                                                       // O método precisa ser abstrato, pois ele vai ser chamado em cada classe de peça específica para que
                                                       // haja o movimento. A regra de movimentos é prevista para cada peça específica //

    }
}
