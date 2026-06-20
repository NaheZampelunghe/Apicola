namespace Apicola.Abstactions
{
    public interface IDbContext<T> : IDbOperation<T> where T : class
    {
    }
}
