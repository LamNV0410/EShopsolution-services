namespace EshopSolution.Extensions.BaseDbContext
{
    public interface IRepository<T> where T : IAggregateRoot
    {
        IBaseRepository BaseRepository { get; }
    }
}
