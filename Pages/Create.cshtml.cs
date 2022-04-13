using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using Treinamento.Mysql.Models;
using Treinamento.Mysql.Repository;

namespace Treinamento.Mysql.Pages
{
    public class CreateModel : PageModel
    {
        private readonly ILogger<CreateModel> _logger;

        [BindProperty]
        public Cliente cliente { get; set; }

        private readonly IClienteRepository _rep;

        public string Mensagem { get; set; }

        public CreateModel(ILogger<CreateModel> logger, IClienteRepository rep)
        {
            _logger = logger;
            _rep = rep;
        }
        public IActionResult OnGet()
        {
            return Page();
        }
        public IActionResult OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            try
            {
                cliente.Id = Guid.NewGuid().ToString();
                _rep.Persistir(cliente);

                Mensagem = "Sucesso";
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Create");
                Mensagem = ex.Message;
            }
            return Page();
        }
    }
}
