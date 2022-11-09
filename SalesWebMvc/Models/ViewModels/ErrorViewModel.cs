using System;

namespace SalesWebMvc.Models.ViewModels
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; } //Id interno na requisi��o para mostra na p�gina de erro
        public string Message { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId); //fun��o para testar se existe o Id do RequestId
    }
}