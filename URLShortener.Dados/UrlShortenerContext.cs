using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using URLShortener.Dados.Models;

namespace URLShortener.Dados
{
    public class UrlShortenerContext : DbContext
    {
        public UrlShortenerContext(DbContextOptions options) : base(options) 
        { 
        
        }
        
        public virtual DbSet<Url> Urls { get; set; }

    }
}
