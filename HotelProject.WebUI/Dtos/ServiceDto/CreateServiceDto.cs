﻿using System.ComponentModel.DataAnnotations;

namespace HotelProject.WebUI.Dtos.ServiceDto
{
    public class CreateServiceDto
    {
        public int ServiceId { get; set; }
        [Required(ErrorMessage ="Servis ikon linki giriniz")]
        public string ServiceIcon { get; set; }
        [Required(ErrorMessage = "Hizmet başlığı giriniz")]
        [StringLength(30,ErrorMessage ="Hizmet başlığı en fazla 100 karakter giriniz")]
        public string Title { get; set; }

        public string Description { get; set; }
    }
}
