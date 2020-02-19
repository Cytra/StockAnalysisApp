using StockAnalysisApp.Data.DbContexts;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;
using System;
using System.Collections.Generic;
using System.Text;
using StockAnalysisApp.Core.DTOs;
using System.Threading.Tasks;
using System.Linq;
using StockAnalysisApp.Logger.Loggers;

namespace StockAnalysisApp.Data.Repositories
{
    public class DcfRepository : IDcfRepository, IDisposable
    {
        public readonly StockDbContext _context;
        private readonly IWindowsLogger _logger;

        public DcfRepository(StockDbContext context, IWindowsLogger logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public void AddDcf(DcfDto dto)
        {
            try
            {
                //_context.Dcfs.Add(dto);
            }
            catch (Exception ex)
            {
                ex.Data.Add(dto.Id, dto);
                _logger.WriteError("Error saving DCF list to DB", ex);
            }
        }

        public void AddDcfList(List<DcfDto> dcfs)
        {
            //try
            //{
            //    foreach (var dcf in dcfs)
            //    {
            //        var existingDcf = _context.Dcfs.FirstOrDefault(x => x.Date == dcf.Date && x.Symbol == dcf.Symbol);
            //        if (existingDcf == null)
            //        {
            //            if (!double.IsNaN(dcf.DCF) && !double.IsNaN(dcf.StockPrice))
            //            {
            //                if(double.IsInfinity(dcf.DCF))
            //                {
            //                    dcf.DCF = 999999999;
            //                }
            //                _logger.WriteInformation($"Saving dcf - {dcf.Symbol}, {dcf.DCF}, {dcf.StockPrice}, {dcf.Date}");
            //                AddDcf(dcf);
            //            }
            //        }
            //    }
            //    _context.SaveChanges();
            //}
            //catch (Exception ex)
            //{
            //    _logger.WriteError("Error saving DCF list to DB", ex);
            //}
            //_logger.WriteInformation("Saved data to DB");
            
        }

        public async Task<List<DcfDto>> GetDcfDto()
        {
            return null;
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
