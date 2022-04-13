using System.ComponentModel.DataAnnotations;

namespace Treinamento.Mysql.Models
{
    public class Cliente
    {
        public string Id { get; set; }

        [Required, StringLength(50)]

        public string Nome { get; set; }
    }
}
