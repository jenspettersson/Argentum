namespace Argentum.Core
{
    public interface IUnitOfWork
    {
        void Commit();
        void Rollback();
    }
}