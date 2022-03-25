using System.Collections.Generic;
using System.Threading.Tasks;

namespace ElasticProject.Data.Interface
{
    public interface IElasticsearchService
    {
        Task ChekIndex(string indexName);
        Task InsertDocument(string indexName, Cities cities);
        Task DeleteIndex(string indexName);
        Task DeleteByIdDocument(string indexName, Cities cities);
        Task InsertBulkDocuments(string indexName, List<Cities> cities);
        Task<Cities> GetDocument(string indexName, string id);
        Task<List<Cities>> GetDocuments(string indexName);
    }
}
