namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        public List<Pessoa> Hospedes { get; set; } = new();
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }

        public Reserva() { }

        public Reserva(int diasReservados)
        {
            DiasReservados = diasReservados;
        }

        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            if (hospedes is null)
                throw new ArgumentNullException(nameof(hospedes));

            if (Suite is null)
                throw new InvalidOperationException("A suíte deve ser cadastrada antes de cadastrar os hóspedes.");

            // Regra: não pode reservar uma suíte com capacidade menor do que a quantidade de hóspedes.
            if (Suite.Capacidade >= hospedes.Count)
                Hospedes = hospedes;
            else
                throw new Exception(
                    $"Capacidade da suíte ({Suite.Capacidade}) é menor que a quantidade de hóspedes ({hospedes.Count}).");
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
            return Hospedes?.Count ?? 0;
        }

        public decimal CalcularValorDiaria()
        {
            if (Suite is null)
                throw new InvalidOperationException("A suíte deve ser cadastrada antes de calcular o valor da diária.");

            var valor = DiasReservados * Suite.ValorDiaria;

            // Regra: Caso os dias reservados forem maior ou igual a 10, conceder um desconto de 10%
            if (DiasReservados >= 10)
                valor *= 0.9m;

            return valor;
        }
    }
}