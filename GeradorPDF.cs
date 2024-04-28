// esta num folder chamado"services"

using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using System;
using System.IO;

namespace App1.Services
{
    public class GeradorPDF
    {
        public void GerarPDF(string nomePaciente, string nomeEnfermeiro, int pontuacaoTotal, int prontuario, int data)
        {
            // Criar um novo documento PDF
            PdfDocument documento = new PdfDocument();

            // Adicionar uma página ao documento
            PdfPage pagina = documento.Pages.Add();

            // Criar um objeto PdfGraphics para desenhar na página
            PdfGraphics graphics = pagina.Graphics;

            // Definir a fonte e o tamanho do texto
            PdfFont fonte = new PdfStandardFont(PdfFontFamily.Helvetica, 12);

            // Escrever texto no PDF (exemplo)
            graphics.DrawString($"Nome do Paciente: {nomePaciente}", fonte, PdfBrushes.Black, new PointF(10, 10));
            graphics.DrawString($"Nome do Enfermeiro: {nomeEnfermeiro}", fonte, PdfBrushes.Black, new PointF(10, 30));
            graphics.DrawString($"Numero do Prontuario: {prontuario}}", fonte, PdfBrushes.Black, new PointF(10, 50));
            graphics.DrawString($"Data do Exame: {data}", fonte, PdfBrushes.Black, new PointF(10, 50));
            graphics.DrawString($"Pontuação Total: {pontuacaoTotal}", fonte, PdfBrushes.Black, new PointF(10, 50));

            // Salvar o documento PDF em um local específico (por exemplo, armazenamento local)
            MemoryStream stream = new MemoryStream();
            documento.Save(stream);
            documento.Close(true);

            // Exemplo: Salvar o PDF em um arquivo no armazenamento local
            string caminhoArquivo = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "MeuDocumentoPDF.pdf");
            File.WriteAllBytes(caminhoArquivo, stream.ToArray());
        }
    }

}
