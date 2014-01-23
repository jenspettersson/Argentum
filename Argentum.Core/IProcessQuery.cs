namespace Argentum.Core
{
    public interface IProcessQuery
    {
        TResult Execute<TResult>(IQuery<TResult> query);
    }
}