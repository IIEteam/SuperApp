﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using OGL.Models;

namespace OGL
{
    public class Category
    {
        public Category()
        {
            this.Ogloszenie_Kategoria = new HashSet<AdCategory>();
        }


        [Key]
        [Display(Name = "ID kategorii: ")]
        public int Id { get; set; }

        [Display(Name = "Nazwa Kategorii: ")]
        [Required]
        public string Nazwa { get; set; }
        [Display(Name = "Id rodzica: ")]
        [Required]
        public int ParentId { get; set; }

        #region seo
        [Display(Name = "Tytuł w Google: ")]
        [MaxLength(72)]
        public string MetaTytul { get; set; }

        [Display(Name = "Opis strony w Google")]
        [MaxLength(160)]
        public string MetaOpis { get; set; }

        [Display(Name = "Słowa kluczowa w Google")]
        [MaxLength(160)]
        public string MetaSlowa { get; set; }

        [Display(Name = "Treść strony: ")]
        [MaxLength(600)]
        public string Tresc { get; set; }
        #endregion
        public ICollection<AdCategory> Ogloszenie_Kategoria { get; set; }

    } }