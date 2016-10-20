using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Democracy.Models
{
    public class Voting
    {
        [Key]
        public int VotingId { get; set; }


        [Required(ErrorMessage = "El campo {0} No puede estar Vacio")]
        [StringLength(50, ErrorMessage = "La longitu maxima debe ser de 50 caracteres y minumo 3", MinimumLength = 3)]
        public string Descripcion { get; set; }


        [Required(ErrorMessage = "El campo {0} No puede estar Vacio")]
        //Display para mostrar lo que queramos y no muestre la vista como ta, en este caso mostraria "StateId"
        [Display(Name ="State")]
        public int StateId { get; set; }


        //para qeu se vea como un tex area, como un cuadro de texto
        [DataType(DataType.MultilineText)]
        public int Remarks { get; set; }


        [Required(ErrorMessage = "El campo {0} No puede estar Vacio")]
        [Display(Name ="Date time start")]
        //para mostrar las fecha
        [DataType(DataType.DateTime)]
        //para dar formato a fecha
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd hh:mm}", ApplyFormatInEditMode = true)]
        public DateTime DateTimeStart { get; set; }


        [Required(ErrorMessage = "El campo {0} No puede estar Vacio")]
        [Display(Name = "Date time and")]
        [DataType(DataType.DateTime)]
        //para dar formato a fecha
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd hh:mm}", ApplyFormatInEditMode = true)]
        public DateTime DateTimeAnd  { get; set; }


        [Required(ErrorMessage = "El campo {0} No puede estar Vacio")]
        [Display(Name = "Is For All Users?")]
        public bool IsForAllUsers { get; set; }


        [Required(ErrorMessage = "El campo {0} No puede estar Vacio")]
        [Display(Name = "Is Enabled Blank Vote ?")]
        public bool IsEnabledBlankVote { get; set; }

        [Display(Name = "Quantity Votes")]
        public int QuantityVotes { get; set; }
        [Display(Name = "Quatity Blank Votes")]
        public int QuatityBlankVotes { get; set; }
        [Display(Name = "Winner")]
        public bool CandidateWinId { get; set; }

    }
}