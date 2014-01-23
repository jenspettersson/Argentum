namespace Argentum.Core
{
    public interface IProcessQuery
    {
        TResult Process<TResult>(IQuery<TResult> query);
    }
}