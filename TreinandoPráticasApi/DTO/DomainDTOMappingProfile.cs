using AutoMapper;
using TreinandoPráticasApi.Entities;

namespace TreinandoPráticasApi.DTO
{
    public class DomainDTOMappingProfile : Profile 
    {
       public DomainDTOMappingProfile() 
       {
            CreateMap<CategoriaEntity, CategoriaDTO>().ReverseMap();
            CreateMap<ProdutoEntity  , ProdutoDTO>().ReverseMap();
            CreateMap<PedidoEntity   , PedidoDTO>().ReverseMap();
            CreateMap<UsuarioEntity, UsuarioDTO>().ReverseMap();
        }
    }
}
