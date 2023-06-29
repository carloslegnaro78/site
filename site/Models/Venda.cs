using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace site.Models
{
    public class Venda
    {
        

        [BindNever]
        public int VendaId { get; set; }
        public List<DetalhesVenda> DetalhesVenda { get; set; }
        [Required(ErrorMessage = "Entre com seu nome")]
        [Display(Name = "Primeiro nome")]
        [StringLength(50)]
        public string PrimeiroNome { get; set; }

        [Required(ErrorMessage ="Entre com seu sobrenome")]
        [Display(Name ="Sobrenome")]
        [StringLength(50)]
        public string Sobrenome { get; set; }

        [Required(ErrorMessage ="Endereço")]
        [StringLength(100)]
        [Display(Name = "Rua")]
        public string Endereco1 { get; set; }

        [Display(Name ="Complemento")]
        public string Endereco2 { get; set; }

        [Required(ErrorMessage ="Código Postal")]
        [Display(Name ="CEP")]
        [StringLength(15, MinimumLength =4)]
        public string CEP { get; set; }

        [StringLength(10)]
        public string Estado { get; set; }


        [StringLength(50)]
        public string Pais { get; set; }


        [StringLength(25)]
        [DataType(DataType.PhoneNumber)]
        [Display(Name ="Telefone")]
        public string Telefone { get; set; }

        [Required]
        [StringLength(50)]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-‌​]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$", 
            ErrorMessage = "Seu email não está no formato correto!")]
        public string Email { get; set; }

        [BindNever]
        [ScaffoldColumn(false)]
        public decimal TotalVenda { get; set; }

        [BindNever]
        [ScaffoldColumn(false)]
        public DateTime DataVenda { get; set; }            
    }
}
