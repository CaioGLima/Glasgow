using System;
using Xamarin.Forms;

namespace GlasGow
{
    public partial class MainPage : ContentPage
    {
        private EscalaGlasgow escalaGlasgow;
        private string nomeEnfermeiro;
        private string dataExame;
        private string nomePaciente;
        private string numProntuario;

        public MainPage()
        {
            InitializeComponent();
            escalaGlasgow = new EscalaGlasgow();

            pickerAberturaOcular.SelectedIndexChanged += PickerAberturaOcular_SelectedIndexChanged;
            pickerRespostaMotora.SelectedIndexChanged += PickerRespostaMotora_SelectedIndexChanged;
            pickerRespostaVerbal.SelectedIndexChanged += PickerRespostaVerbal_SelectedIndexChanged;
        }

        private void PickerAberturaOcular_SelectedIndexChanged(object sender, EventArgs e)
        {
            VerificarSelecoes();
        }

        private void PickerRespostaMotora_SelectedIndexChanged(object sender, EventArgs e)
        {
            VerificarSelecoes();
        }

        private void PickerRespostaVerbal_SelectedIndexChanged(object sender, EventArgs e)
        {
            VerificarSelecoes();
        }

        private void VerificarSelecoes()
        {
            if (pickerAberturaOcular.SelectedItem != null && pickerRespostaVerbal.SelectedItem != null && pickerRespostaMotora.SelectedItem != null)
            {
                CalcularPontuacao();
            }
        }

        private void CalcularPontuacao()
        {
            try
            {
                string opcaoAberturaOcular = pickerAberturaOcular.SelectedItem?.ToString();
                string opcaoRespostaVerbal = pickerRespostaVerbal.SelectedItem?.ToString();
                string opcaoRespostaMotora = pickerRespostaMotora.SelectedItem?.ToString();

                Console.WriteLine($"Abertura Ocular: {opcaoAberturaOcular}, Resposta Verbal: {opcaoRespostaVerbal}, Resposta Motora: {opcaoRespostaMotora}");

                if (string.IsNullOrWhiteSpace(opcaoAberturaOcular) || string.IsNullOrWhiteSpace(opcaoRespostaVerbal) || string.IsNullOrWhiteSpace(opcaoRespostaMotora))
                {
                    DisplayAlert("Erro", "Por favor, selecione todas as opções.", "OK");
                    return;
                }

                int pontuacaoAberturaOcular = escalaGlasgow.ObterPontuacaoAberturaOcular(opcaoAberturaOcular);
                int pontuacaoRespostaVerbal = escalaGlasgow.ObterPontuacaoRespostaVerbal(opcaoRespostaVerbal);
                int pontuacaoRespostaMotora = escalaGlasgow.ObterPontuacaoRespostaMotora(opcaoRespostaMotora);

                Console.WriteLine($"Pontuação Abertura Ocular: {pontuacaoAberturaOcular}, Pontuação Resposta Verbal: {pontuacaoRespostaVerbal}, Pontuação Resposta Motora: {pontuacaoRespostaMotora}");

                int pontuacaoTotal = escalaGlasgow.CalcularPontuacao(pontuacaoAberturaOcular, pontuacaoRespostaVerbal, pontuacaoRespostaMotora);
                lblPontuacao.Text = $"Pontuação total: {pontuacaoTotal}";
            }
            catch (Exception ex)
            {
                DisplayAlert("Erro", $"Ocorreu um erro ao calcular a pontuação: {ex.Message}", "OK");
                Console.WriteLine(ex);
            }
        }

        private async void OnCalculateButtonClicked(object sender, EventArgs e)
        {
            try
            {
                string opcaoAberturaOcular = pickerAberturaOcular.SelectedItem?.ToString();
                string opcaoRespostaVerbal = pickerRespostaVerbal.SelectedItem?.ToString();
                string opcaoRespostaMotora = pickerRespostaMotora.SelectedItem?.ToString();

                if (string.IsNullOrWhiteSpace(opcaoAberturaOcular) || string.IsNullOrWhiteSpace(opcaoRespostaVerbal) || string.IsNullOrWhiteSpace(opcaoRespostaMotora))
                {
                    await DisplayAlert("Erro", "Por favor, selecione todas as opções.", "OK");
                    return;
                }

                int pontuacaoAberturaOcular = escalaGlasgow.ObterPontuacaoAberturaOcular(opcaoAberturaOcular);
                int pontuacaoRespostaVerbal = escalaGlasgow.ObterPontuacaoRespostaVerbal(opcaoRespostaVerbal);
                int pontuacaoRespostaMotora = escalaGlasgow.ObterPontuacaoRespostaMotora(opcaoRespostaMotora);

                int pontuacaoTotal = escalaGlasgow.CalcularPontuacao(pontuacaoAberturaOcular, pontuacaoRespostaVerbal, pontuacaoRespostaMotora);
                await DisplayAlert("Pontuação Calculada", $"Sua pontuação total é {pontuacaoTotal}", "OK");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Erro", $"Ocorreu um erro ao calcular a pontuação: {ex.Message}", "OK");
                Console.WriteLine(ex);
            }
        }

        private async void BtnInfo_Clicked(object sender, EventArgs e)
        {
            if (sender is Button clickedButton)
            {
                string inputText = string.Empty;
                string promptTitle = string.Empty;

                switch (clickedButton.Text)
                {
                    case "Adicionar Nome do Enfermeiro":
                        promptTitle = "Nome do Enfermeiro";
                        inputText = await DisplayPromptAsync(promptTitle, "Digite o nome do enfermeiro:");
                        nomeEnfermeiro = inputText;
                        txtNomeEnfermeiro.Text = inputText;
                        break;
                    case "Adicionar Data do Exame":
                        promptTitle = "Data do Exame";
                        inputText = await DisplayPromptAsync(promptTitle, "Digite a data do exame:");
                        dataExame = inputText;
                        txtDataExame.Text = inputText;
                        break;
                    case "Adicionar Nome do Paciente":
                        promptTitle = "Nome do Paciente";
                        inputText = await DisplayPromptAsync(promptTitle, "Digite o nome do paciente:");
                        nomePaciente = inputText;
                        txtNomePaciente.Text = inputText;
                        break;
                    case "Adicionar Número do Prontuário":
                        promptTitle = "Número do Prontuário";
                        inputText = await DisplayPromptAsync(promptTitle, "Digite o número do prontuário:");
                        numProntuario = inputText;
                        txtNumProntuario.Text = inputText;
                        break;
                }

                if (!string.IsNullOrWhiteSpace(inputText))
                {
                    DisplayAlert("Informação Adicionada", $"A informação foi adicionada com sucesso: {inputText}", "OK");
                }
            }
        }
    }
}






