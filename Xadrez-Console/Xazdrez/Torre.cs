using Tabuleiro_xadrez;

namespace Xadrez
{
    class Torre : Peca
    {
        // construtor //
        public Torre(Tabuleiro tab, Cor cor) : base(tab, cor) 
                                                            
        {
        }

        public override string ToString()
        {
            return "T";
        }
    }
}
