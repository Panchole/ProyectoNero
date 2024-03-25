namespace ProyectoNero.Client;

public interface IUnitOfWork
{
    ICarruselIndexRepository CarruselIndex { get; }
}
