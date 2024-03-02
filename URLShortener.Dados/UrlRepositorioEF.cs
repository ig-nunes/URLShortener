using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using URLShortener.Dados.Models;

namespace URLShortener.Dados
{
    public class UrlRepositorioEF : IRepository
    {
        private readonly UrlShortenerContext _context;

        public UrlRepositorioEF(UrlShortenerContext context)
        {
            _context = context;
        }

        public async Task Delete(string urlRequest)
        {
            var url = await _context.Urls.FirstOrDefaultAsync(u => u.SUrl == urlRequest);
            if (url != null)
            {   
                _context.Urls.Remove(url);
                await _context.SaveChangesAsync();
            } else
            {
                throw new InvalidOperationException("A url passada não está salva no banco de dados");
            }
        }

        public async Task<Url?> Get(string urlReq)
        {
            var url = await _context.Urls.FirstOrDefaultAsync(url => url.SUrl.ToLower() == urlReq.ToLower());
            return url;
        }

        public async Task<List<Url>> GetAll()
        {
            return await _context.Urls.ToListAsync();
        }

        public async Task<Url?> Post(Url url) 
        {
            _context.Urls.Add(url);
            await _context.SaveChangesAsync();
            return url;
            
        }
    }
}
