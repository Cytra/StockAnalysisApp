using StockAnalysisApp.Data.DbContexts;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;
using System;
using System.Collections.Generic;
using System.Text;
using StockAnalysisApp.Core.DTOs;
using System.Threading.Tasks;
using System.Linq;

namespace StockAnalysisApp.Data.Repositories
{
    public class DcfRepository : IDcfRepository, IDisposable
    {
        public readonly StockDbContext _context;

        public DcfRepository(StockDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void AddDcf(DcfDto dto)
        {
            _context.Dcfs.Add(dto);
            _context.SaveChanges();
        }

        public void AddDcfList(List<DcfDto> dcfs)
        {
            foreach(var dcf in dcfs)
            {
                var existingDcf = _context.Dcfs.FirstOrDefault(x => x.date == dcf.date && x.symbol == dcf.symbol);
                if(existingDcf == null)
                {
                    _context.Dcfs.Add(dcf);
                }
            }
            _context.SaveChanges();
        }

        public async Task<List<DcfDto>> GetDcfDto()
        {
            return await _context.Dcfs.ToListAsync();
        }

        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
        }
    }
}
