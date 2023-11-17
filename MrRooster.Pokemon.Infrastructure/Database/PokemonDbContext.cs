using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using MRooster.Pokemon.Domain.Options;
using System.Data;

namespace MrRooster.Pokemon.Infrastructure.Database;

public class PokemonDbContext
{
    private readonly ConnectionStringOptions _options;

    public PokemonDbContext(IOptions<ConnectionStringOptions> options)
    {
        _options = options.Value;
    }

    public IDbConnection CreateConnection() => new SqlConnection(_options.SqlConnection);
}

