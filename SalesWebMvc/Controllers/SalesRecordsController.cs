using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebMvc.Services;
using SalesWebMvc.Models;

namespace SalesWebMvc.Controllers
{
    public class SalesRecordsController : Controller
    {
        private readonly SalesRecordService _salesRecordService;

        public SalesRecordsController(SalesRecordService salesRecordService)
        {
            _salesRecordService = salesRecordService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> SimpleSearch(DateTime? minDate, DateTime? maxDate)
        {
            if (!minDate.HasValue)
            {
                minDate = new DateTime(DateTime.Now.Year, 1, 1);
                //Caso não tenha valor na pesquisa, irá fixar em 01/01/atual
            }
            if (!maxDate.HasValue)
            {
                maxDate = DateTime.Now;
                //Caso não tenha valor na pesquisa, irá fixar na data atual
            }
            ViewData["minDate"] = minDate.Value.ToString("yyyy-MM-dd");
            ViewData["maxDate"] = maxDate.Value.ToString("yyyy-MM-dd");
            //Tudo acima é para continuar mostrando a data selecionada na barra após a pesquisa-> View
            var result = await _salesRecordService.FindByDateAsync(minDate, maxDate);
            //Chamada Assincrona para pesquisar as vendas
            return View(result);
        }
        public async Task<IActionResult> GroupingSearch(DateTime? minDate, DateTime? maxDate)
        {
            if (!minDate.HasValue)
            {
                minDate = new DateTime(DateTime.Now.Year, 1, 1);
                //Caso não tenha valor na pesquisa, irá fixar em 01/01/atual
            }
            if (!maxDate.HasValue)
            {
                maxDate = DateTime.Now;
                //Caso não tenha valor na pesquisa, irá fixar na data atual
            }
            ViewData["minDate"] = minDate.Value.ToString("yyyy-MM-dd");
            ViewData["maxDate"] = maxDate.Value.ToString("yyyy-MM-dd");
            //Tudo acima é para continuar mostrando a data selecionada na barra após a pesquisa-> View
            var result = await _salesRecordService.FindByDateGroupingAsync(minDate, maxDate);
            //Chamada Assincrona para pesquisar as vendas
            return View(result);
        }
    }
}
