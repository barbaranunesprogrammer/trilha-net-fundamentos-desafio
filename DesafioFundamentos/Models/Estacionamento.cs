namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        // Preço inicial cobrado para estacionar
        private decimal precoInicial = 0;

        // Preço por hora estacionada
        private decimal precoPorHora = 0;

        // Lista para armazenar as placas dos veículos estacionados
        private List<string> veiculos = new List<string>();

        // Construtor - recebe o preço inicial e o preço por hora
        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        // Método para adicionar um veículo ao estacionamento
        public void AdicionarVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            string placa = Console.ReadLine()?.Trim().ToUpper(); // Remove espaços e deixa maiúsculo

            // Valida se a placa não é vazia
            if (string.IsNullOrWhiteSpace(placa))
            {
                Console.WriteLine("Placa inválida! Tente novamente.");
                return;
            }

            // Verifica se a placa já está cadastrada
            if (veiculos.Any(v => v.Equals(placa, StringComparison.OrdinalIgnoreCase)))
            {
                Console.WriteLine("Esse veículo já está estacionado!");
                return;
            }

            // Adiciona na lista
            veiculos.Add(placa);
            Console.WriteLine($"Veículo {placa} adicionado com sucesso!");
        }

        // Método para remover um veículo do estacionamento
        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");
            string placa = Console.ReadLine()?.Trim().ToUpper();

            // Verifica se o veículo está estacionado (ignora maiúsculas/minúsculas)
            if (veiculos.Any(v => v.Equals(placa, StringComparison.OrdinalIgnoreCase)))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");

                // Valida se o usuário digitou um número válido
                if (!int.TryParse(Console.ReadLine(), out int horas) || horas < 0)
                {
                    Console.WriteLine("Quantidade de horas inválida!");
                    return;
                }

                // Calcula o valor total
                decimal valorTotal = precoInicial + precoPorHora * horas;

                // Remove todas as ocorrências dessa placa (caso tenha duplicada)
                veiculos.RemoveAll(v => v.Equals(placa, StringComparison.OrdinalIgnoreCase));

                Console.WriteLine($"O veículo {placa} foi removido.");
                Console.WriteLine($"Valor total a pagar: R$ {valorTotal}");
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente.");
            }
        }

        // Método para listar todos os veículos estacionados
        public void ListarVeiculos()
        {
            // Verifica se existe algum veículo na lista
            if (veiculos.Any())
            {
                Console.WriteLine("Veículos estacionados:");
                int contador = 1;
                foreach (var veiculo in veiculos)
                {
                    Console.WriteLine($" {contador}. [{veiculo}]");
                    contador++;
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
