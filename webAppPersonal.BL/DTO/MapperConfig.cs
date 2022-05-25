using AutoMapper;
using webAppPersonal.BL.Models;
using webAppPersonal.BL.DTO;

namespace webAppPersonal.BL.DTO
{
    public class MapperConfig
    {
        public static MapperConfiguration MapperConfiguartion() {
            return new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<persona, personaDTO>(); // Metodos Get
                cfg.CreateMap<personaDTO, persona>(); // Metodos Post - Put

                cfg.CreateMap<producto, productoDTO>(); // Metodos Get
                cfg.CreateMap<productoDTO, producto>(); // Metodos Post - Put
            });
        }
    }
}
