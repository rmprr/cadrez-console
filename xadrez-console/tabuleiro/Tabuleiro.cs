using System;
using System.Collections.Generic;
using System.Text;

namespace tabuleiro
{
    class Tabuleiro
    {

        public int linhas { get; set; }
        public int colunas { get; set; }
        private Peca[,] pecas; // matriz que tem as peças presentes no tabuleiro

        public Tabuleiro(int linhas, int colunas )
        {
            this.linhas = linhas;
            this.colunas = colunas;
            pecas = new Peca[linhas, colunas];
        }

        public Peca peca(int linha, int coluna)
        {
            return pecas[linha, coluna]; // return da peça presente no tabuleiro nesta posição
        }

        public Peca peca(Posicao pos)
        {
            return pecas[pos.linha, pos.coluna]; // retorna a peça que está nesta posicao pos
        }

        public bool existePeca(Posicao pos) // vai validar se existe alguma peça na posição do tabuleiro e já valida se a posição é valida para o tamanho do tabuleiro
        {
            posicaoValida(pos); // verifica se as posição é valida para o tamanho do tabuleiro
            return peca(pos) != null; // se coindição for true é porque existe a peça nesta posição do tabuleiro
        }


        public void colocarPeca(Peca p, Posicao pos)
        {
            if (existePeca(pos))
            {
                throw new TabuleiroException("Já existe uma peça nessa posição!");
            }
            pecas[pos.linha, pos.coluna] = p; // coloca a peça na posição "pos" do tabuleiro (matriz de pecas)
            p.posicao = pos; // atualiza o atributo posicao da peça 
        }


        public Peca retirarPeca(Posicao pos)
        {
            if (peca(pos) == null)
            {
                return null;
            }

            Peca aux = peca(pos);
            aux.posicao = null;

            pecas[pos.linha, pos.coluna] = null;

            return aux;
        }


        public bool posicaoValida(Posicao pos) // vai verificar se a posição não sai fora do tabuleiro
        {
            if (pos.linha < 0 || pos.linha >= linhas || pos.coluna < 0 || pos.coluna >= colunas)
            {
                return false;
            }
            return true;
        }

        public void validarPosicao(Posicao pos)
        {
            if (!posicaoValida(pos))
                throw new TabuleiroException("Posição inválida!"); // excepção a usar comko mensagem para o utilizador 
        }

    }
}
