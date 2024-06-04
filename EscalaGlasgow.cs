using System;
using System.Collections.Generic;

namespace GlasGow
{
    public class EscalaGlasgow
    {
        private Dictionary<string, int> pontuacoesAberturaOcular;
        private Dictionary<string, int> pontuacoesRespostaVerbal;
        private Dictionary<string, int> pontuacoesRespostaMotora;

        public EscalaGlasgow()
        {
            pontuacoesAberturaOcular = new Dictionary<string, int>
            {
                { "Espontânea", 4 },
                { "À voz", 3 },
                { "À dor", 2 },
                { "Nenhuma", 1 }
            };

            pontuacoesRespostaVerbal = new Dictionary<string, int>
            {
                { "Orientado", 5 },
                { "Confuso", 4 },
                { "Palavras inapropiadas", 3 },
                { "Sons incompreensíveis", 2 },
                { "Nenhuma", 1 }
            };

            pontuacoesRespostaMotora = new Dictionary<string, int>
            {
                { "Obedece comandos", 6 },
                { "Localiza dor", 5 },
                { "Retira à dor", 4 },
                { "Flexão anormal", 3 },
                { "Extensão anormal", 2 },
                { "Nenhuma", 1 }
            };
        }

        public int ObterPontuacaoAberturaOcular(string opcao)
        {
            if (pontuacoesAberturaOcular.TryGetValue(opcao, out int pontuacao))
            {
                return pontuacao;
            }
            return 0;
        }

        public int ObterPontuacaoRespostaVerbal(string opcao)
        {
            if (pontuacoesRespostaVerbal.TryGetValue(opcao, out int pontuacao))
            {
                return pontuacao;
            }
            return 0;
        }

        public int ObterPontuacaoRespostaMotora(string opcao)
        {
            if (pontuacoesRespostaMotora.TryGetValue(opcao, out int pontuacao))
            {
                return pontuacao;
            }
            return 0;
        }

        public int CalcularPontuacao(int aberturaOcular, int respostaVerbal, int respostaMotora)
        {
            return aberturaOcular + respostaVerbal + respostaMotora;
        }
    }
}
