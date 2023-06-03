using Npgsql;

namespace web_api_min.Repository;
class BaseRepository
{
  private static readonly string ConnectionString =
    "Host=localhost;Port=5432;Database=gama_net;Username=postgres;Password=123456";

  protected NpgsqlConnection GetConnection()
  {
    var dbConnection = new NpgsqlConnection(ConnectionString);
    dbConnection.Open();

    return dbConnection;
  }
}