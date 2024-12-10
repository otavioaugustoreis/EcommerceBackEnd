namespace TreinandoPráticasApi._1___Application.Models
{
    public readonly record struct UsuarioModel(int Id
                                            , string DsNome
                                            , string DsCPF
                                            , int NrIdade
                                            , string DsEmail
                                            , int PedidoId)
        { }
    
}
