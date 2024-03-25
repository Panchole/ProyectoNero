namespace ProyectoNero.Client;

public class UnitOfWork : IUnitOfWork
{
    public UnitOfWork(ICarruselIndexRepository carruselIndexRepository)
    {
        CarruselIndex = carruselIndexRepository;
    }
    public ICarruselIndexRepository CarruselIndex { get; }
}
