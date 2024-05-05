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
        if (sender == btnNome)
        {
            nomeEnfermeiro = txtNomeEnfermeiro.Text;
        }
        else if (sender == btnData)
        {
            dataExame = txtDataExame.Text;
        }
        else if (sender == btnNomePaciente)
        {
            nomePaciente = txtNomePaciente.Text;
        }
        else if (sender == btnNumProntuario)
        {
            numProntuario = txtNumProntuario.Text;
        }
    }

    private void PickerAberturaOcular_SelectedIndexChanged(object sender, EventArgs e)
    {
        string opcaoSelecionada = pickerAberturaOcular.SelectedItem.ToString();
        int pontuacaoAberturaOcular = escalaGlasgow.ObterPontuacaoAberturaOcular(opcaoSelecionada);
        CalcularPontuacao(pontuacaoAberturaOcular);
    }

    private void PickerRespostaMotora_SelectedIndexChanged(object sender, EventArgs e)
    {
        string opcaoSelecionada = pickerRespostaMotora.SelectedItem.ToString();
        int pontuacaoRespostaMotora = escalaGlasgow.ObterPontuacaoRespostaMotora(opcaoSelecionada);
        CalcularPontuacao(pontuacaoRespostaMotora);
    }

    private void PickerRespostaVerbal_SelectedIndexChanged(object sender, EventArgs e)
    {
        string opcaoSelecionada = pickerRespostaVerbal.SelectedItem.ToString();
        int pontuacaoRespostaVerbal = escalaGlasgow.ObterPontuacaoRespostaVerbal(opcaoSelecionada);
        CalcularPontuacao(pontuacaoRespostaVerbal);
    }

    private void CalcularPontuacao(int pontuacaoParte)
    {
        int pontuacaoAberturaOcular = escalaGlasgow.ObterPontuacaoAberturaOcular(pickerAberturaOcular.SelectedItem.ToString());
        int pontuacaoRespostaVerbal = escalaGlasgow.ObterPontuacaoRespostaVerbal(pickerRespostaVerbal.SelectedItem.ToString());
        int pontuacaoRespostaMotora = escalaGlasgow.ObterPontuacaoRespostaMotora(pickerRespostaMotora.SelectedItem.ToString());

        int pontuacaoTotal = escalaGlasgow.CalcularPontuacao(pontuacaoAberturaOcular, pontuacaoRespostaVerbal, pontuacaoRespostaMotora);
        lblPontuacao.Text = $"Pontuação total: {pontuacaoTotal}";
        
    // Mostrar o pop-up para gerar o PDF
        MostrarPopUpGerarPDF();
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
