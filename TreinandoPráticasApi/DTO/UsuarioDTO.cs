using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TreinandoPráticasApi.Entities;

namespace TreinandoPráticasApi.DTO
{
    //Aprendendo a usar o usuário DTO com record e struct
    //obs: No obsidian tem a explicação de cada 
    public readonly record struct UsuarioDTO(int Id
                                            , string DsCPF
                                            , int NrIdade
                                            , string DsEmail
                                            , int PedidoId)
    { 


    //Jeito padrão de DTO
    //public class UsuarioDTO
    //{
    //    public int Id { get; set; }

    //    [Column("ds_nome")]
    //    [Required]
    //    public string DsNome { get; set; }

    //    [Column("ds_cpf")]
    //    [Required]
    //    public string DsCPF { get; set; }

    //    [Column("nr_idade")]
    //    [Required]
    //    public int NrIdade { get; set; }

    //    [Column("ds_email")]
    //    [Required]
    //    public string DsEmail { get; set; }

    //    [Column("fk_pedido")]
    //    public int PedidoId { get; set; }
    //}


}
