using AutoMapper;
using System.ComponentModel;
using TransportationAPI.Attributes;

namespace TransportationAPI.Extensions
{
    /// <summary>
    ///  Ignore the properties which will decorate with the NoMap attribute.
    /// </summary>
    /// <example>
    /// Use the IgnoreNoMap method while defining the Mapping as shown below.
    /// <code>
    /// cfg.CreateMap<Employee, EmployeeDTO>()
    /// .IgnoreNoMap();
    /// </code>
    /// </example>
    public static class IgnoreNoMapExtensions
    {
        public static IMappingExpression<TSource, TDestination> IgnoreNoMap<TSource, TDestination>(
            this IMappingExpression<TSource, TDestination> expression)
        {
            var sourceType = typeof(TSource);
            foreach (var property in sourceType.GetProperties())
            {
                PropertyDescriptor descriptor = TypeDescriptor.GetProperties(sourceType)[property.Name];
                NoMapAttribute attribute = (NoMapAttribute)descriptor.Attributes[typeof(NoMapAttribute)];
                if (attribute != null)
                {
                    expression.ForMember(property.Name, opt => opt.Ignore());
                }
            }

            return expression;
        }
    }
}
