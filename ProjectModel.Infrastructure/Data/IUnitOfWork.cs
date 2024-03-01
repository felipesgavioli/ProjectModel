namespace ProjectModel.Infrastructure.Data
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> Commit();
    }
}