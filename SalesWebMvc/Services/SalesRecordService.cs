using SalesWebMvc.Data;
using SalesWebMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace SalesWebMvc.Services
{
    public class SalesRecordService
    {
        private readonly SalesWebMvcContext _context;
        //Faz a ligação com o banco de dados

        public SalesRecordService(SalesWebMvcContext context)
        {
            _context = context;
        }

        public async Task<List<SalesRecord>> FindByDateAsync(DateTime? minDate, DateTime? maxDate)
        {
            var result = from obj in _context.SalesRecord select obj; //pega o salesrecord do tipo dbset e construir um obj result do tipo IQuearyable
            if (minDate.HasValue)
            {
                result = result.Where(x => x.Date >= minDate.Value);
                //Caso haja valor, procura ele se a data for igual ou maior da data minima
            }
            if (maxDate.HasValue)
            {
                result = result.Where(x => x.Date <= maxDate.Value);
                //Caso haja valor, procura ele se a data for igual ou menor da data maxima
            }
            return await result
                .Include(x => x.Seller)
                .Include(x => x.Seller.Department)
                .OrderByDescending(x => x.Date)
                .ToListAsync();
            //Retorna o resultado assincrono em uma lista incluindo o vendedor, departamento e organizando da maior data pra menor
        }

        //Por utilizar a operação GroupBy, o retorno será agrupado em uma coleção IGrouping
        //Então será uma Task de Lista de IGrouping de Departament e SalesRecord
        public async Task<List<IGrouping<Department, SalesRecord>>> FindByDateGroupingAsync(DateTime? minDate, DateTime? maxDate)
        {
            var result = from obj in _context.SalesRecord select obj; //pega o salesrecord do tipo dbset e construir um obj result do tipo IQuearyable
            if (minDate.HasValue)
            {
                result = result.Where(x => x.Date >= minDate.Value);
                //Caso haja valor, procura ele se a data for igual ou maior da data minima
            }
            if (maxDate.HasValue)
            {
                result = result.Where(x => x.Date <= maxDate.Value);
                //Caso haja valor, procura ele se a data for igual ou menor da data maxima
            }
            return await result
                .Include(x => x.Seller)
                .Include(x => x.Seller.Department)
                .OrderByDescending(x => x.Date)
                .GroupBy(x => x.Seller.Department) //Agrupa o resultado por Departamento
                .ToListAsync();
            //Retorna o resultado assincrono em uma lista incluindo o vendedor, departamento e organizando da maior data pra menor
        }
    }
}
