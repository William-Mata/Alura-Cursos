using  bytebank_Modelos.bytebank.Modelos.ADM.SistemaInterno;
using  bytebank_Modelos.bytebank.Modelos.ADM.Utilitario;

namespace  bytebank_Modelos.bytebank.Modelos.ADM.Funcionarios
{
    public abstract class FuncionarioAutenticavel : Funcionario, IAutenticavel
    {
        public string Senha { get; set; }
        internal AutenticacaoUtil Autenticacao { get; set; } = new AutenticacaoUtil();

        public FuncionarioAutenticavel(double salario, string cpf)
            : base(salario, cpf)
        {

        }

        public bool Autenticar(string senha)
        {
            return Autenticacao.ValidarSeha(this.Senha, senha);
        }
    }
}
