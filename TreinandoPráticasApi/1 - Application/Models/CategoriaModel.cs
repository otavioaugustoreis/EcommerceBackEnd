using System.ComponentModel.DataAnnotations.Schema;

namespace TreinandoPráticasApi._1___Application.Models
{
    public  record  CategoriaModel(int Id, 
                                   string DsNome,
                                   string DsImagem)
    {
    }
}
