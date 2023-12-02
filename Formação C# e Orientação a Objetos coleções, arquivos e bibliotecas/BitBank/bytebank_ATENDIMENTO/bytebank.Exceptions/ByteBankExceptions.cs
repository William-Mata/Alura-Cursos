namespace bytebank_ATENDIMENTO.bytebank.Exceptions;

[Serializable]
public class ByteBankExceptions : Exception
{
	public ByteBankExceptions() { }
	public ByteBankExceptions(string message) : base("Ocorreu a seguinte Exceção: " + message) { }
	public ByteBankExceptions(string message, Exception inner) : base(message, inner) { }
	protected ByteBankExceptions(
	  System.Runtime.Serialization.SerializationInfo info,
	  System.Runtime.Serialization.StreamingContext context) : base(info, context) { } 
}
