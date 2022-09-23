using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CotacaoMoeda.Modelo
{
    public class Cotacao
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(ErrorMessage = "O Id é obrigatório.")]
        public int Id { get; set; }

        [Display(Name = "Nome")]
        [StringLength(150, MinimumLength = 5, ErrorMessage = "Este campo deve ter no mínimo 5 e no máximo 100 caracteres.")]
        public string Nome { get; set; } = "";

        [Display(Name = "Valor Compra")]
        [Required(ErrorMessage = "Valor compra obrigatório.")]
        [Column(TypeName = "decimal(15,5)")]
        public decimal ValorCompra { get; set; }

        [Display(Name = "Valor Venda")]
        [Required(ErrorMessage = "Valor venda obrigatório.")]
        [Column(TypeName = "decimal(15,5)")]
        public decimal ValorVenda { get; set; }

        [Display(Name = "Data de Inclusão")]
        [Required(ErrorMessage = "Data de inclusão obrigatório.")]
        public DateTime DataHoraCotacao { get; set; }





    }
}
