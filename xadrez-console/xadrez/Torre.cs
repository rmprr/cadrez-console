using tabuleiro;

namespace xadrez
{
    class Torre : Peca
    {
        public Torre(Tabuleiro tab, Cor cor) : base(tab, cor)
        {

        }

        public override string ToString()
        {
            return "T";
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

            // verificando acima
            pos.definirValores(posicao.linha - 1, posicao.coluna);
            while (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
                // verifica se a posicao tem uma peça adeversaria
                if (tab.peca(pos) != null && tab.peca(pos).cor != this.cor)
                    break;

                pos.linha -= 1;
            }

            // verificando abaixo
            pos.definirValores(posicao.linha + 1, posicao.coluna);
            while (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
                // verifica se a posicao tem uma peça adeversaria
                if (tab.peca(pos) != null && tab.peca(pos).cor != this.cor)
                    break;

                pos.linha += 1;
            }

            // verificando a direita
            pos.definirValores(posicao.linha, posicao.coluna + 1);
            while (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
                // verifica se a posicao tem uma peça adeversaria
                if (tab.peca(pos) != null && tab.peca(pos).cor != this.cor)
                    break;

                pos.coluna += 1;
            }

            // verificando a esquerda
            pos.definirValores(posicao.linha, posicao.coluna - 1);
            while (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
                // verifica se a posicao tem uma peça adeversaria
                if (tab.peca(pos) != null && tab.peca(pos).cor != this.cor)
                    break;

                pos.coluna -= 1;
            }

            return mat;
        }

    }
}
