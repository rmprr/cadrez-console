using tabuleiro;

namespace xadrez
{
    class Bispo : Peca
    {
        public Bispo(Tabuleiro tab, Cor cor) : base(tab, cor)
        {

        }

        public override string ToString()
        {
            return "B";
        }


        private bool podeMover(Posicao pos) // verifica se esta peça pode ser movida para a posicao de destino
        {
            Peca p = tab.peca(pos); // retorna a peça que está no tabuleiro na posição pos

            return p == null || p.cor != this.cor;
        }

        public override bool[,] movimentosPossiveis()
        {
            bool[,] mat = new bool[tab.linhas, tab.colunas];

            Posicao pos = new Posicao(0, 0);

            return mat;
        }


    }
}
