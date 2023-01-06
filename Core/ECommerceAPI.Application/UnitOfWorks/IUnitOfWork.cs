namespace ECommerceAPI.Application.UnitOfWorks
{
    public interface IUnitOfWork
    {
        Task SaveAsync();
    }
}
