using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using TinyIoC;

namespace Argentum.Core
{
    //Todo: Temporary registrator to test TinyIOC functionality
    public class GenericRegistrator : IRegistrator
    {
        public void RegisterFrom(Assembly assembly, Type interfaceType, Lifestyle lifestyle = Lifestyle.PerRequest, bool allowMultipleImplementations = false)
        {
            var types = new List<Type>();
            var genericTypes = assembly.GetTypes()
                                .Where(type => 
                                    type.GetInterfaces().Any(x => x.IsGenericType && x.GetGenericTypeDefinition() == interfaceType)).ToList();
            
            types.AddRange(genericTypes);

            var nonGenericTypes = assembly.GetTypes().Where(type => interfaceType.IsAssignableFrom(type) && type.IsClass);

            types.AddRange(nonGenericTypes);

            if(types.Count() > 1 && !allowMultipleImplementations)
                throw new MultipleImplementaionsNotAllowedException(string.Format("Multiple implementations of {0} is not allowed!", interfaceType.FullName));

            Register(interfaceType, lifestyle, types);
        }

        private static void Register(Type interfaceType, Lifestyle lifestyle, List<Type> types)
        {
            if (types.Count() == 1)
            {
                var registerOptions = TinyIoCContainer.Current.Register(interfaceType, types.First());
                if (lifestyle == Lifestyle.PerRequest)
                    registerOptions.AsMultiInstance();
                else
                {
                    registerOptions.AsSingleton();
                }
            }
            else
            {
                var multiRegisterOptions = TinyIoCContainer.Current.RegisterMultiple(interfaceType, types);
                if (lifestyle == Lifestyle.PerRequest)
                    multiRegisterOptions.AsMultiInstance();
                else
                {
                    multiRegisterOptions.AsSingleton();
                }
            }
        }
    }
}