﻿using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.OData.Edm;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Ogretmen
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public int DersId { get; set; }
        
        [DisplayName("Öğretmen Adı")]
        public string OgretmenName { get; set; }
        [DisplayName("Öğretmen Soyadı")]
        public string OgretmenLastName { get; set; }
        [DisplayName("Öğretmen TC Kimlik")]
        public string OgretmenTc { get; set; }
        [DisplayName("Doğum Tarihi")]

        public DateTime OgretmenBirthDate { get; set; }
        



    }
}
