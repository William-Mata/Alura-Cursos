using Alura.ByteBank.Dados.Contexto;

namespace Alura.ByteBank.Testes.Infraestrutura;

public class ByteBankConbtextoTestes
{
    [Fact]
    public void TestarConexaoContextoBdSqlServer()
    {
        // Arrange 
        var contexto = new ByteBankContexto();
        bool conectado;

        // Act
        try
        {
            conectado = contexto.Database.CanConnect();

            if (!conectado)
            {
                throw new Exception("Falha na conexão com o banco de dados.");
            }

        }catch (Exception ex)
        {
            conectado = false;
        }

        // Assert
        Assert.True(conectado);
    }

}
