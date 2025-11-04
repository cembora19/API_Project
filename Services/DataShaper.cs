using System.Dynamic;
using System.Reflection;
using Services.Contracts;

namespace Entities
{
    public class DataShaper<T> : IDataShaper<T>
        where T : class
    {
        public PropertyInfo[] Properties { get; set; }
        public DataShaper()
        {
            Properties = typeof(T)
                .GetProperties(BindingFlags.Public | BindingFlags.Instance);
        }
        public IEnumerable<ExpandoObject> ShapeData(IEnumerable<T> entities, string fieldString)
        {
            var requiredFields = GetRequiredProperties(fieldString);
            return FetchData(entities, requiredFields);
        }

        public ExpandoObject ShapeData(T entity, string fieldString)
        {
            var requiredProperties = GetRequiredProperties(fieldString);
            return FetchDataForEntity(entity, requiredProperties);
        }

        private IEnumerable<PropertyInfo> GetRequiredProperties(string fieldString)
        {
            var requiredFields = new List<PropertyInfo>();
            if (!string.IsNullOrWhiteSpace(fieldString))
            {
                var fields = fieldString.Split(',',
                    StringSplitOptions.RemoveEmptyEntries);

                foreach (var field in fields)
                {
                    var property = Properties
                        .FirstOrDefault(pi => pi.Name.Equals(field.Trim(),
                        StringComparison.InvariantCultureIgnoreCase));
                    if (property is null)
                        continue;
                    requiredFields.Add(property);
                }
            }
            else
            {
                requiredFields = Properties.ToList();
            }

            return requiredFields;
        }

        private ExpandoObject FetchDataForEntity(T entity, IEnumerable<PropertyInfo> requiredProperties)
        {
            var shapeObject = new ExpandoObject();
            foreach (var property in requiredProperties)
            {
                var objectPropertyValue = property.GetValue(entity);
                shapeObject.TryAdd(property.Name, objectPropertyValue);
            }
            return shapeObject;
        }

        private IEnumerable<ExpandoObject> FetchData(IEnumerable<T> entities, IEnumerable<PropertyInfo> requiredProperties)
        {
            var shapedData = new List<ExpandoObject>();
            foreach (var entity in entities)
            {
                var shapeObject = FetchDataForEntity(entity, requiredProperties);
                shapedData.Add(shapeObject);
            }
            return shapedData;
        }
    }
}