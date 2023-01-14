using System.Data;

namespace EventSourcing;

public interface IDbConnectionProvider
{
    IDbConnection Get();
}
