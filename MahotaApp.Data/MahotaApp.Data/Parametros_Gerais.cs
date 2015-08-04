using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MahotaApp.Data
{
    public class Moeda
    {
        [Key]
        public string moedaId { get; set; }

        [Required]
        public string descricao { get; set; }
        public double compra { get; set; }
        public double venda { get; set; }
        public DateTime? data { get; set; }
        public string codigoIso { get; set; }

        public virtual ICollection<Pendente> listaPendentes { get; set; }

        public Moeda() { }

        public Moeda(ref string moeda, ref string descricao, ref double compra, ref double venda, ref DateTime data)
        {
            this.moedaId = moeda;
            this.descricao = descricao;
            this.compra = compra;
            this.venda = venda;
            this.data = data;

        }
    }

    public class Empresa
    {
        [Key]
        public string empresaId { get; set; }

        public string nome { get; set; }
        public string nuit { get; set; }
        public string morada { get; set; }
    }

    public class ApplicationUser : IdentityUser
    {
        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(100)]
        public string LastName { get; set; }

        [Required]
        public byte Level { get; set; }

        [Required]
        public DateTime JoinDate { get; set; }

    }
      
}
