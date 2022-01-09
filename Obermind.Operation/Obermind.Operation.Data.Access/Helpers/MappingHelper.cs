using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Obermind.Operation.Data.Access.Mappings.Agreements;
using Obermind.Operation.Data.Access.Mappings.Contracts;

namespace Obermind.Operation.Data.Access.Helpers
{
    public static class MappingsHelper
    {
        public static IEnumerable<IMapping> GetMainMappings()
        {
            var assemblyTypes = typeof(UserMapping).GetTypeInfo().Assembly.DefinedTypes;
            var mappings = assemblyTypes
                // ReSharper disable once AssignNullToNotNullAttribute
                .Where(t => t.Namespace != null && t.Namespace.Contains(typeof(UserMapping).Namespace))
                .Where(t => typeof(IMapping).GetTypeInfo().IsAssignableFrom(t));
            mappings = mappings.Where(x => !x.IsAbstract);
            return mappings.Select(m => (IMapping)Activator.CreateInstance(m.AsType())).ToArray();
        }
    }
}
