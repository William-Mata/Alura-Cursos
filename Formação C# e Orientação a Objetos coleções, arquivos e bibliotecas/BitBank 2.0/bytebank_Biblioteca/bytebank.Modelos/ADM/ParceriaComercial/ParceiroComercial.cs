using  bytebank_Modelos.bytebank.Modelos.ADM.SistemaInterno;
using  bytebank_Modelos.bytebank.Modelos.ADM.Utilitario;

namespace  bytebank_Modelos.bytebank.Modelos.ADM.ParceiraComercial
{
    public class ParceiroComercial : IAutenticavel
    {
        public string Senha { get; set; }
        internal AutenticacaoUtil Autenticacao { get; set; } = new AutenticacaoUtil();

        public bool Autenticar(string senha)
        {
            return Autenticacao.ValidarSeha(this.Senha, senha);
        }
    }
}
