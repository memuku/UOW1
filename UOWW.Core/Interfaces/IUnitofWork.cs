namespace UOWW.Core.Interfaces
{
    public interface IUnitofWork : IDisposable
    {
        IProjectRepository Projects { get; }
        Task<int> CompletedAsync();
    }
}
