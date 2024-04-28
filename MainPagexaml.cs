//using App1.Services
using App1.models;
using System;
using Xamarin.Forms;

public partial class MainPage : ContentPage
{
    readonly EscalaGlasgow escalaGlasgow;


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
    }


    private void GerarPDF_Clicked(object sender, EventArgs e)
    {
        // Lógica para gerar o PDF com as informações da Escala de Glasgow
    }
}

