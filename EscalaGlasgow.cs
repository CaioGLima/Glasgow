// esta dentro do folder chamado "models"

using System.Collections.Generic;
using System;

namespace App1.models
{
    public class EscalaGlasgow
    {
        public int CalcularPontuacao(int pontuacaoAberturaOcular, int pontuacaoRespostaVerbal, int pontuacaoRespostaMotora)
        {
            // Verificar se as pontuações são válidas (maiores ou iguais a zero)
            if (pontuacaoAberturaOcular < 0 || pontuacaoRespostaVerbal < 0 || pontuacaoRespostaMotora < 0)
            {
                throw new ArgumentException("As pontuações devem ser maiores ou iguais a zero.");
            }

            // Calcular a pontuação total da Escala de Glasgow
            int pontuacaoTotal = pontuacaoAberturaOcular + pontuacaoRespostaVerbal - pontuacaoRespostaMotora;
            return pontuacaoTotal;
        }

        private int ObterPontuacao(string opcaoSelecionada, Dictionary<string, int> pontuacoes)
        {
            // Verificar se a opção selecionada está no dicionário de pontuações
            if (pontuacoes.ContainsKey(opcaoSelecionada))
            {
                return pontuacoes[opcaoSelecionada];
            }
            else
            {
                return 0; // Retornar zero se a opção não for encontrada
            }
        }

        public int ObterPontuacaoAberturaOcular(string opcaoSelecionada)
        {
            // Dicionário de pontuações para Abertura Ocular
            Dictionary<string, int> pontuacoesAberturaOcular = new Dictionary<string, int>
        {
            { "4 - Espontânea", 4 },
            { "3 - À voz", 3 },
            { "2 - À dor", 2 },
            { "1 - Nenhuma", 1 }
        };

            return ObterPontuacao(opcaoSelecionada, pontuacoesAberturaOcular);
        }

        public int ObterPontuacaoRespostaVerbal(string opcaoSelecionada)
        {
            // Dicionário de pontuações para Resposta Verbal
            Dictionary<string, int> pontuacoesRespostaVerbal = new Dictionary<string, int>
        {
            { "5 - Orientado", 5 },
            { "4 - Confuso", 4 },
            { "3 - Palavra", 3 },
            { "2 - Sons", 2 },
            { "1 - Nenhuma", 1 }
        };

            return ObterPontuacao(opcaoSelecionada, pontuacoesRespostaVerbal);
        }

        public int ObterPontuacaoRespostaMotora(string opcaoSelecionada)
        {
            // Dicionário de pontuações para Resposta Motora
            Dictionary<string, int> pontuacoesRespostaMotora = new Dictionary<string, int>
        {
            { "6 - Obedece", -6 },
            { "5 - Localiza", -5 },
            { "4 - Flete", -4 },
            { "3 - Flexão Anormal", -3 },
            { "2 - Extensão", -2 },
            { "1 - Nenhuma", -1 }
        };

            return ObterPontuacao(opcaoSelecionada, pontuacoesRespostaMotora);
        }
    }
}
