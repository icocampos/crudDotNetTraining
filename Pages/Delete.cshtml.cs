using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using Treinamento.Mysql.Models;
using Treinamento.Mysql.Repository;

namespace Treinamento.Mysql.Pages
{
    public class DeleteModel : PageModel
    {
        private readonly ILogger<DeleteModel> _logger;
        public IEnumerable<Cliente> Clientes { get; set; }
        private readonly IClienteRepository _rep;
        public string Mensagem { get; set; }
        public DeleteModel(ILogger<DeleteModel> logger, IClienteRepository rep)
        {
            _logger = logger;
            _rep = rep;
        }

        public IActionResult OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            try
            {
                _rep.Excluir(id);
                Mensagem = "Sucesso";
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Create");
                Mensagem = "Falha";
            }
            return RedirectToPage("Index");
        }
    }
}
