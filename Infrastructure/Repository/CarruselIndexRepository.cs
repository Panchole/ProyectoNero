
using Dapper;
using Microsoft.Data.SqlClient;

namespace ProyectoNero.Client;

public class CarruselIndexRepository : ICarruselIndexRepository
{
    private readonly IConfiguration _configuration;

    public CarruselIndexRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task<IEnumerable<CarruselIndex>> GetAll()
    {
        var sql = "SELECT * FROM CarruselIndex WHERE Estado = 1";
        using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
        {
            connection.Open();
            var result = await connection.QueryAsync<CarruselIndex>(sql);
            return result.ToList();
        }
    }

    public async Task<CarruselIndex?> GetById(int id)
    {
        var sql = "SELECT * FROM CarruselIndex WHERE IdImagen = @Id and Estado = 1";
        using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
        {
            connection.Open();
            var result = await connection.QuerySingleOrDefaultAsync<CarruselIndex>(sql, new { Id = id });
            return result;
        }
    }
}
