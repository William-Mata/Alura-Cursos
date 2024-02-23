namespace Alura.Adopet.Console.Services.Interfaces;

public interface IServiceAPI<T>
{
    Task<HttpResponseMessage> CreateAsync(T obj);
    Task<IEnumerable<T>?> ListAsync();
}