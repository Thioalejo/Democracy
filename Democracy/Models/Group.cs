using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Democracy.Models
{
    public class Group
    {
        [Key]
        public int GroupId { get; set; }

        //para obligar a llenar el campo
        [Required(ErrorMessage = "El campo {0} No puede estar Vacio")]

        //para definir la longitud del campo
        [StringLength(50, ErrorMessage = "La longitu maxima debe ser de 50 caracteres y minumo 3", MinimumLength = 3)]
        public string Descripcion { get; set; }
    }
}