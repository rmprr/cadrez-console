using System;
using System.Collections.Generic;
using System.Text;

namespace tabuleiro
{
    abstract class Peca
    {

        public Posicao posicao { get; set; }
        public Cor cor { get; protected set; }
        public int qteMovimentos { get; protected set; }
        public Tabuleiro tab { get; protected set; }

        public Peca(Tabuleiro tab, Cor cor)
        {
            this.posicao = null; // posição atual da peça (inicialmente é null e é atualizada aquando a sua inserção no tabuleiro)
            this.tab = tab;
            this.cor = cor;
            this.qteMovimentos = 0;
        }


        public bool existeMovimentosPossiveis()
        {
            bool[,] mat = movimentosPossiveis();
            for (int i = 0; i < tab.linhas; i++)
            {
                for (int j = 0; j < tab.colunas; j++)
                {
                    if (mat[i, j] == true)
                    {
                        return true;
                    }
                }
            }

            return false;
        }


        public bool podeMoverPara(Posicao pos)
        {
            return movimentosPossiveis()[pos.linha, pos.coluna];
        }


        public void incrementarQteMovimentos()
        {
            qteMovimentos++;
        }


        public void decrementarQteMovimentos()
        {
            qteMovimentos--;
        }


        public abstract bool[,] movimentosPossiveis();

    }
}
