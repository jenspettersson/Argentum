using System;
using System.Reflection;

namespace Argentum.Core
{
    public interface IRegistrator
    {
        void RegisterFrom(Assembly assembly, Type interfaceType, Lifestyle lifestyle, bool allowMultipleImplementations);
    }
}