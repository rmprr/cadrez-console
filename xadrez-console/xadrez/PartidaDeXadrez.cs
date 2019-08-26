using System;
using System.Collections.Generic;
using tabuleiro;

namespace xadrez
{
    class PartidaDeXadrez
    {

        public Tabuleiro tab { get; private set; }
        public int turno { get; private set; }
        public Cor jogadorAtual { get; private set; }
        public bool terminada { get; private set; }
        private HashSet<Peca> pecas;
        private HashSet<Peca> capturadas;
        private bool xeque;


        public PartidaDeXadrez()
        {
            tab = new Tabuleiro(8, 8);
            turno = 1;
            jogadorAtual = Cor.White;
            terminada = false;
            pecas = new HashSet<Peca>();
            capturadas = new HashSet<Peca>();
            colocarPecas();
        }


        public Peca executaMovimento(Posicao origem, Posicao destino)
        {
            Peca p = tab.retirarPeca(origem); // retira a peça da posição onde está
            p.incrementarQteMovimentos(); // vai incrementar a quantidade de movimentos (vai fazer andar a peça)
            Peca pecaCapturada = tab.retirarPeca(destino); // vai capturar a peça que estava nessa posição , se for caso disso
            tab.colocarPeca(p, destino); // coloca a peça no posicao do tabuleiro para onde ela foi movimentada

            if (pecaCapturada != null) // vai guardar a peça capturada no conjunto de peças capturadas
                capturadas.Add(pecaCapturada);


            return pecaCapturada;
        }


        public HashSet<Peca> pecasCapturadas(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (var x in capturadas)
            {
                if (x.cor == cor)
                {
                    aux.Add(x);
                }
            }

            return aux;
        }


        public HashSet<Peca> pecasEmJogo(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (var x in pecas)
            {
                if (x.cor == cor)
                {
                    aux.Add(x);
                }
            }

            aux.ExceptWith(pecasCapturadas(cor));
            return aux;
        }


        private Cor adversaria(Cor cor)
        {
            if (cor == Cor.White)
            {
                return Cor.Black;
            }
            else
            {
                return Cor.White;
            }
        }


        private Peca rei(Cor cor)
        {
            foreach (var item in pecasEmJogo(cor))
            {
                if (item is Rei)
                    return item;
            }

            return null;
        }


        public bool estaEmXeque(Cor cor)
        {
            Peca R = rei(cor);
            if (R == null)
                throw new TabuleiroException("Não tem rei da cor " + cor + " no tabuleiro. Erro na aplicação.");

            foreach (var item in pecasEmJogo(adversaria(cor)))
            {
                bool[,] mat = item.movimentosPossiveis();
                if (mat[R.posicao.linha, R.posicao.coluna])
                {
                    return true;
                }
            }

            return false;
        }



        public void realizaJogada(Posicao origem, Posicao destino)
        {
            Peca pecaCapturada = executaMovimento(origem, destino);
            // confirmar se não vai ficar em cheque 
            if (estaEmXeque(jogadorAtual))
            {
                desfazMovimento(origem, destino, pecaCapturada);
                throw new TabuleiroException("Não pode realizar esta jogada. O seu Rei está em Xeque!!!");
            }

            if (estaEmXeque(adversaria(jogadorAtual)))
            {
                xeque = true;
            }
            else
            {
                xeque = false;
            }


            turno++;
            mudaJogador();
        }


        private void desfazMovimento(Posicao origem, Posicao destino, Peca pecaCapturada)
        {
            Peca p = tab.retirarPeca(destino);
            p.decrementarQteMovimentos();

            if (pecaCapturada != null)
            {
                tab.colocarPeca(pecaCapturada, destino); // voltar a colocar a peça capturada no sitio onde estava
                capturadas.Remove(pecaCapturada);
            }

            tab.colocarPeca(p, origem); // volta a meter a peça movida no sitio onde estava
        }


        public void validarPosicaoDeOrigem(Posicao pos)
        {
            if (tab.peca(pos) == null)
                throw new TabuleiroException("Não existe nenhuma peça na posição escolhida. Escolha outra posição.");

            if (jogadorAtual != tab.peca(pos).cor)
                throw new TabuleiroException("A peça escolhida não lhe pertence.");

            if (!tab.peca(pos).existeMovimentosPossiveis())
                throw new TabuleiroException("A peça escolhida não tem movimentos possíveis.");
        }


        public void validarPosicaoDeDestino(Posicao origem, Posicao destino)
        {
            if (!tab.peca(origem).podeMoverPara(destino))
            {
                throw new TabuleiroException("Posição de destino inválida!");
            }
        }

        private void mudaJogador()
        {
            jogadorAtual = jogadorAtual == Cor.White ? Cor.Black : Cor.White;
        }


        private void colocarNovaPeca(char coluna, int linha, Peca peca)
        {
            tab.colocarPeca(peca, new PosicaoXadrez(coluna, linha).toPosicao());
            pecas.Add(peca);
        }


        private void colocarPecas()
        {
            colocarNovaPeca('c', 1, new Torre(tab, Cor.White));
            colocarNovaPeca('c', 2, new Torre(tab, Cor.White));
            colocarNovaPeca('d', 2, new Torre(tab, Cor.White));
            colocarNovaPeca('e', 2, new Torre(tab, Cor.White));
            colocarNovaPeca('e', 1, new Torre(tab, Cor.White));
            colocarNovaPeca('d', 1, new Rei(tab, Cor.White));

            colocarNovaPeca('c', 7, new Torre(tab, Cor.Black));
            colocarNovaPeca('c', 8, new Torre(tab, Cor.Black));
            colocarNovaPeca('d', 7, new Torre(tab, Cor.Black));
            colocarNovaPeca('e', 7, new Torre(tab, Cor.Black));
            colocarNovaPeca('e', 8, new Torre(tab, Cor.Black));
            colocarNovaPeca('d', 8, new Rei(tab, Cor.Black));
        }

    }
}
