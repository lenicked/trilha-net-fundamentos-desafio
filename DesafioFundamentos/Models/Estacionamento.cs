namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            // TODO: Pedir para o usuário digitar uma placa (ReadLine) e adicionar na lista "veiculos"
            // *IMPLEMENTE AQUI*
            Console.WriteLine("Digite a placa do veículo para estacionar:");

            string placa = Console.ReadLine().ToUpper();

            if (ValidarPlaca(placa))
            {
                Console.WriteLine($"A placa {placa} digitada pelo usuário é válida");
                veiculos.Add(placa);
            }
            else
            {
                Console.WriteLine($"A placa {placa} digitada pelo usuário não é válida");
            }

        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");

            // Pedir para o usuário digitar a placa e armazenar na variável placa
            // *IMPLEMENTE AQUI*
            string placa = "";

            // Verifica se o veículo existe
            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");

                // TODO: Pedir para o usuário digitar a quantidade de horas que o veículo permaneceu estacionado,
                // TODO: Realizar o seguinte cálculo: "precoInicial + precoPorHora * horas" para a variável valorTotal                
                // *IMPLEMENTE AQUI*
                int horas = 0;
                decimal valorTotal = 0; 

                // TODO: Remover a placa digitada da lista de veículos
                // *IMPLEMENTE AQUI*

                Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                for (int veiculo = 0; veiculo < veiculos.Count; veiculo++)
                {
                    Console.WriteLine($"O veículo {veiculos[veiculo]} está estacionado na vaga {veiculo + 1}");
                }

                Console.WriteLine($"Total de veículos estacionados: {veiculos.Count}");
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }

        public bool ValidarPlaca(string placa)
        {
            // Validar o formato da placa -> 
            // Validação tanto no modelo antigo (ABC1234) como no modelo mercosul (ABC1D34)

            // Padronização da placa
            string placaNormalizada = placa.Trim().ToUpper().Replace("-", "");

            // Verificar a quantidade de caracteres passada
            if (placaNormalizada.Length == 7)
            {
                // Verificação do Modelo tradicional
                if (Char.IsDigit(placaNormalizada[4]))
                {
                    for (int item = 0; item < 3; item++)
                    {
                        if (!Char.IsLetter(placaNormalizada[item]))
                        {
                            return false;
                        }
                    }

                    for (int item = 3; item < placaNormalizada.Length; item++)
                    {
                        if (!Char.IsDigit(placaNormalizada[item]))
                        {
                            return false;
                        }
                    }

                }
                // Verificação do modelo Mercosul
                else if (Char.IsLetter(placaNormalizada[4]))
                {
                    for (int item = 0; item < 3; item++)
                    {
                        if (!Char.IsLetter(placaNormalizada[item]))
                        {
                            return false;
                        }
                    }

                    if (!Char.IsDigit(placaNormalizada[3]))
                    {
                        return false;
                    }

                    if (!Char.IsDigit(placaNormalizada[5]))
                    {
                        return false;
                    }

                    if (!Char.IsDigit(placaNormalizada[6]))
                    {
                        return false;
                    }
                }   
                return true;
            }
            else
            {
                return false;
            }
            
        }
    }
}
