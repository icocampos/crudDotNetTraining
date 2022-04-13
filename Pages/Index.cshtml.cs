using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Treinamento.Mysql.Models;
using Treinamento.Mysql.Repository;

namespace Treinamento.Mysql.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IEnumerable<Cliente> Clientes { get; set; }

        private readonly IClienteRepository _rep;

        public IndexModel(ILogger<IndexModel> logger, IClienteRepository rep)
        {
            _logger = logger;
            _rep = rep;
        }

        public IActionResult OnGet()
        {
            _logger.LogInformation("Buscando dados");
            Clientes = _rep.Listar();

            return Page();
        }
    }
}
