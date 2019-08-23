using System;
using System.Collections.Generic;
using System.Text;

namespace tabuleiro
{
    class Peca
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





    }
}
