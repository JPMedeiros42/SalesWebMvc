using System;

namespace SalesWebMvc.Models.ViewModels
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; } //Id interno na requisição para mostra na página de erro
        public string Message { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId); //função para testar se existe o Id do RequestId
    }
}