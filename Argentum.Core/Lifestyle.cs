using System;

namespace Argentum.Core
{
    public enum Lifestyle
    {
        Singleton,
        PerRequest
    }

    public class MultipleImplementaionsNotAllowedException : Exception
    {
        public MultipleImplementaionsNotAllowedException(string message) : base(message){}
    }
}