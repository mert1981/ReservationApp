using System.ComponentModel.DataAnnotations;

namespace HotelProject.WebApi.Dtos.ServiceDto
{
    public class UpdateServiceDto
    {
        public int ServiceId { get; set; }
        [Required(ErrorMessage = "Servis ikon linki giriniz")]
        public string ServiceIcon { get; set; }
        [Required(ErrorMessage = "Hizmet başlığı giriniz")]
        [StringLength(100, ErrorMessage = "Hizmet başlığı en fazla 100 karakter olabilir.")]
        public string Title { get; set; }
        [Required(ErrorMessage ="Hizmet açıklaması girin")]
        public string Description { get; set; }
    }
}
