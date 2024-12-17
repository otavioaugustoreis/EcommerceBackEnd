using AutoMapper;
using TreinandoPráticasApi.Entities;

namespace TreinandoPráticasApi._1___Application.Models
{
    public class DomainModelMappingProfile : Profile
    {
        public DomainModelMappingProfile()
        {

            CreateMap<CategoriaEntity, CategoriaModelResponse>().ReverseMap();
            CreateMap<ProdutoEntity, ProdutoModel>().ReverseMap();
            CreateMap<PedidoEntity, PedidoModel>().ReverseMap();
            CreateMap<UsuarioEntity, UsuarioModel>().ReverseMap();
            CreateMap<CategoriaEntity, CategoriaModelUpdateRequest>().ReverseMap();
        }
    }

   }

