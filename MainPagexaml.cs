//using App1.Services
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.PancakeView;

public partial class MainPage : ContentPage
{
    readonly EscalaGlasgow escalaGlasgow;
    readonly SfPdfDocument document;
    private string nomeEnfermeiro;
    private string dataExame;
    private string nomePaciente;
    private string numProntuario;


    public MainPage()
    {
        InitializeComponent();
        escalaGlasgow = new EscalaGlasgow();
        document = new SfPdfDocument();

        pickerAberturaOcular.SelectedIndexChanged += PickerAberturaOcular_SelectedIndexChanged;
        pickerRespostaMotora.SelectedIndexChanged += PickerRespostaMotora_SelectedIndexChanged;
        pickerRespostaVerbal.SelectedIndexChanged += PickerRespostaVerbal_SelectedIndexChanged;
    }

    private void BtnInfo_Clicked(object sender, EventArgs e)
    {
        // Verifica qual botão foi clicado e atualiza a variável correspondente
        if(sender is Button clickedButton)
        {
            if (clickedButton == btnNome)
            {
                nomeEnfermeiro = txtNomeEnfermeiro.Text;
            }
            else if (clickeButton == btnData)
            {
                dataExame = txtDataExame.Text;
            }
            else if (clickedButton == btnNomePaciente)
            {
                nomePaciente = txtNomePaciente.Text;
            }
            else if (clickedButton == btnNumProntuario)
            {
                numProntuario = txtNumProntuario.Text;
            }
          }  
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
    
private async void GerarPDF_Clicked(object sender, EventArgs e)
    {
        // Lógica para gerar o PDF com as informações da Escala de Glasgow
       string conteudoPDF = $"Nome do Enfermeiro: {nomeEnfermeiro}\n" +
                             $"Data do Exame: {dataExame}\n" +
                             $"Nome do Paciente: {nomePaciente}\n" +
                             $"Número do Prontuário: {numProntuario}\n" +
                             $"Pontuação Abertura Ocular: {pontuacaoAberturaOcular}\n" +
                             $"Pontuação Resposta Verbal: {pontuacaoRespostaVerbal}\n" +
                             $"Pontuação Resposta Motora: {pontuacaoRespostaMotora}\n" +
                             $"Pontuação Total: {pontuacaoTotal}\n";

        string nomeArquivo = "Exame_Escala_Glasgow.pdf";
        string caminhoArquivo = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), nomeArquivo);

        using (MemoryStream stream = new MemoryStream())
        {
            // Cria o documento PDF
            using (PdfDocument pdfDocument = new PdfDocument())
            {
                // Adiciona uma página ao documento
                PdfPage page = pdfDocument.Pages.Add();

                // Adiciona o conteúdo ao PDF
                PdfGraphics graphics = page.Graphics;
                PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 12);
                graphics.DrawString(conteudoPDF, font, PdfBrushes.Black, new PointF(10, 10));

                // Salva o PDF no caminho especificado
                pdfDocument.Save(stream);
            }

            // Escreve o arquivo PDF no dispositivo
            File.WriteAllBytes(caminhoArquivo, stream.ToArray());
        }

        // Mostra uma mensagem ao usuário informando que o PDF foi gerado com sucesso
        await DisplayAlert("PDF Gerado", "O PDF foi gerado com sucesso!", "OK");
    }
}
}






