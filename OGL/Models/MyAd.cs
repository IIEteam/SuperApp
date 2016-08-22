using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OGL.Models
{
    public class MyAd
    {
        public MyAd()
        {
            this.Ogloszenie_Kategoria = new HashSet<AdCategory>();
        }
        [Display(Name = "Id: ")]
        public int Id { get; set; }

        [Display(Name = "Treść ogłoszenia: ")]
        [MaxLength(600)]
        public string Tresc { get; set; }

        [Display(Name = "Tytuł ogłoszenia: ")]
        [MaxLength(70)]
        public string Tytul { get; set; }

        [Display(Name = "Data dodania: ")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime DataDodania { get; set; }

        [Display(Name = "Stan: ")]
        [ScaffoldColumn(false)]
        public int Stan { get; set; }

        [Display(Name = "Data ostatniej edycji: ")]
        public DateTime? OstatnioEdytowane { get; set; }

        [Display(Name = "Id ostatniej edycji: ")]
        public string IdOstatnioEdytowane { get; set; }

        public string UzytkownikId { get; set; }
        public virtual ICollection<AdCategory>
            Ogloszenie_Kategoria
        { get; set; }
        public virtual MyUser MyUser { get; set; }
    }

}