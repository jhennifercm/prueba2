using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCventa.Models
{
    public class Vent
    {
        public enum TipoEntrega {
            Domicilio,
            Empresa,
            Fabrica

        }
        [Key]
        public int VentaId { get; set; }

        [Required]
        public DateTime fecha { get; set; }

        [Required]
        public string Producto { get; set; }

        [Required]
        public int Cantidad { get; set; }

        public TipoEntrega entrega { get; set; }

    }
}