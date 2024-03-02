using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using URLShortener.Dados.Models;

namespace URLShortener.Dados
{
    public interface IRepository
    {
        Task<Url?> Post(Url url);
        Task<Url?> Get(string url);
        Task<List<Url>> GetAllUrlsAsync();
    }
}
