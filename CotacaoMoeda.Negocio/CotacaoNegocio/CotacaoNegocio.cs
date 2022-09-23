using CotacaoMoeda.Infra.Entity;
using CotacaoMoeda.Modelo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CotacaoMoeda.Negocio.CotacaoNegocio
{
    public class CotacaoNegocio : ICotacaoNegocio
    {

        private readonly AppDbContext _context;

        public CotacaoNegocio(AppDbContext context)
        {
            _context = context; 
        }
        public async Task Incluir(Cotacao cotacao)
        {
         await _context.Cotacao.AddAsync(cotacao);
         await _context.SaveChangesAsync();
        }

        public async Task<List<Cotacao>> ObterLista()
        {
            return await _context.Cotacao.ToListAsync();
        }
    }
}
