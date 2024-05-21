// esta dentro do folder chamado "models"

namespace GlasGow.NewFolder
{    
    public class EscalaGlasgow    
    {        
        public int ObterPontuacaoAberturaOcular(string resposta)        
        {            
            switch (resposta)            
            {                
                case "Espontânea":                    
                    return 4;
                case "Ao estímulo verbal":                    
                    return 3;                
                case "Ao estímulo doloroso":                    
                    return 2;                
                case "Nenhuma":                    
                    return 1;                
                default:                    
                    return 0;            
            }        
        }

        public int ObterPontuacaoRespostaVerbal(string resposta)        
        {           
            switch (resposta)            
            {                
                case "Orientado":                    
                    return 5;                
                case "Confuso":                    
                    return 4;                
                case "Palavras inadequadas":                    
                    return 3;                
                case "Sons incompreensíveis":                    
                    return 2;                
                case "Nenhuma":                    
                    return 1;                
                default:                    
                    return 0;            
            }        
        }

        public int ObterPontuacaoRespostaMotora(string resposta)        
        {            
            switch (resposta)            
            {     
                case "Obedece comandos":                    
                   return 6;                
                case "Localiza dor":                    
                    return 5;                
                case "Retira à dor":                    
                    return 4;                
                case "Flexão anormal":                    
                    return 3;                
                case "Extensão anormal":                    
                    return 2;                
                case "Nenhuma":                    
                    return 1;                
                default:                    
                    return 0;            
            }        
        }
        public int CalcularPontuacao(int aberturaOcular, int respostaVerbal, int respostaMotora)       
        {            
            return aberturaOcular + respostaVerbal + respostaMotora;        
        }  
    }  
}
