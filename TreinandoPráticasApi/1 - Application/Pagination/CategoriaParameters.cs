namespace TreinandoPráticasApi._1___Application.Pagination
{
    public class CategoriaParameters
    {
        const int maxPageSize = 50;
        public int PageNumber { get; set; } = 1;


        //Tamanho da página desejada
        private int _pageSize = 10;

        //Validando PageSize
        public int PageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = (value > maxPageSize) ? maxPageSize : value;
            }
        }

    }
}
