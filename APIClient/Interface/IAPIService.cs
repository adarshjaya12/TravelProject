using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace APIClient.Interface
{
    public interface IAPIService
    {
        Task<List<T>> GetCollectionAsync<T>(string path);
        Task<T> GetItemAsync<T>(string path);

    }
}
