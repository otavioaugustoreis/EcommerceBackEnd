namespace TreinandoPráticasApi.Validators
{
    public  class CpfUtil
    {
        public static bool ValidarFormatoCpf(string cpf)
        {
            cpf = LimparCpf(cpf);

    
            if (cpf.Length != 11 || cpf.All(c => c == cpf[0])) return false;

            
            int soma = 0;
            for (int i = 0; i < 9; i++)
                soma += (cpf[i] - '0') * (10 - i);

            int digito1 = soma % 11;
            digito1 = digito1 < 2 ? 0 : 11 - digito1;

            
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += (cpf[i] - '0') * (11 - i);

            int digito2 = soma % 11;
            digito2 = digito2 < 2 ? 0 : 11 - digito2;

           
            return cpf[9] - '0' == digito1 && cpf[10] - '0' == digito2;
        }

        private static string LimparCpf(string cpf)
        {
            if (string.IsNullOrWhiteSpace(cpf))
                return string.Empty;

            return cpf.Replace(".", "").Replace("-", "").Trim();
        }

    }
}
