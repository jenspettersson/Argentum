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

            if(DuplicateImplementationsExists(types) && !allowMultipleImplementations)
                throw new MultipleImplementaionsNotAllowedException(string.Format("Multiple implementations of {0} is not allowed!", interfaceType.FullName));

            Register(interfaceType, lifestyle, types);
        }

        private static bool DuplicateImplementationsExists(IEnumerable<Type> types)
        {
            var currentInterfaces = new List<Type>();

            foreach (var type in types)
            {
                foreach (var @interface in type.GetInterfaces())
                {
                    if (currentInterfaces.Contains(@interface))
                        return true;

                    currentInterfaces.Add(@interface);
                }
                
            }

            return false;
        }

        private static void Register(Type interfaceType, Lifestyle lifestyle, List<Type> types)
        {
            if (!DuplicateImplementationsExists(types))
            {
                foreach (var type in types)
                {
                    var typeInterface = type.GetInterfaces().First(x => x.Name == interfaceType.Name);


                    var registerOptions = TinyIoCContainer.Current.Register(typeInterface, type);
                    if (lifestyle == Lifestyle.PerRequest)
                        registerOptions.AsMultiInstance();
                    else
                    {
                        registerOptions.AsSingleton();
                    }
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