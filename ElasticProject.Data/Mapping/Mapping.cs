using Nest;

namespace ElasticProject.Data
{
    public static class Mapping
    {
        public static CreateIndexDescriptor CitiesMapping(this CreateIndexDescriptor descriptor)
        {
            return descriptor.Map<Cities>(m => m.Properties(p => p
                .Keyword(k => k.Name(n => n.Id))
                .Text(t => t.Name(n => n.City))
                .Text(t => t.Name(n => n.Region))
                .Number(t => t.Name(n => n.Population))
                .Date(t => t.Name(n => n.CreateDate)))
            );
        }
    }
}
