namespace Argentum.Core
{
    public interface IHandleQuery<in TQuery, out TResult> where TQuery : IQuery<TResult>
    {
        TResult HandleQuery(TQuery query);
    }
}