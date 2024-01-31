namespace FS0623_BackEnd_ContoCorrente
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Inserisci l'intestatario del conto: ");
            string intestatario = Console.ReadLine();

            Console.Write("Inserisci l'importo del versamento iniziale (deve essere almeno 1000): ");
            double versamentoIniziale;
            while (!double.TryParse(Console.ReadLine(), out versamentoIniziale) || versamentoIniziale < 1000)
            {
                Console.Write("Input non valido. Inserisci un numero maggiore o uguale a 1000: ");
            }

            ContoCorrente conto = new ContoCorrente(intestatario);
            conto.ApriConto(versamentoIniziale);
            Console.WriteLine($"Saldo: {conto.Saldo}");

            while (true)
            {
                Console.WriteLine("Scegli un'opzione:");
                Console.WriteLine("1. Versamento");
                Console.WriteLine("2. Prelievo");
                Console.WriteLine("3. Visualizza saldo");
                Console.WriteLine("4. Esci");

                int scelta;
                while (!int.TryParse(Console.ReadLine(), out scelta) || scelta < 1 || scelta > 4)
                {
                    Console.Write("Scelta non valida. Inserisci un numero tra 1 e 4: ");
                }

                switch (scelta)
                {
                    case 1:
                        Console.Write("Inserisci l'importo del versamento: ");
                        double versamento;
                        while (!double.TryParse(Console.ReadLine(), out versamento))
                        {
                            Console.Write("Input non valido. Inserisci un numero: ");
                        }
                        conto.Versamento(versamento);
                        Console.WriteLine($"Saldo: {conto.Saldo}");
                        break;
                    case 2:
                        Console.Write("Inserisci l'importo del prelievo: ");
                        double prelievo;
                        while (!double.TryParse(Console.ReadLine(), out prelievo))
                        {
                            Console.Write("Input non valido. Inserisci un numero: ");
                        }
                        conto.Prelievo(prelievo);
                        Console.WriteLine($"Saldo: {conto.Saldo}");
                        break;
                    case 3:
                        Console.WriteLine($"Saldo: {conto.Saldo}");
                        break;
                    case 4:
                        return;
                }
            }
        }
    }

    public class ContoCorrente
    {
        public string Intestatario { get; private set; }
        public double Saldo { get; private set; }
        public bool IsAperto { get; private set; }

        public ContoCorrente(string intestatario)
        {
            Intestatario = intestatario;
            IsAperto = false;
        }

        public void ApriConto(double versamentoIniziale)
        {
            if (IsAperto)
            {
                throw new Exception("Il conto è già aperto.");
            }

            if (versamentoIniziale < 1000)
            {
                throw new Exception("Il versamento iniziale deve essere almeno di 1000 euro.");
            }

            Saldo = versamentoIniziale;
            IsAperto = true;
        }

        public void Versamento(double importo)
        {
            if (!IsAperto)
            {
                throw new Exception("Il conto non è aperto.");
            }

            Saldo += importo;
        }

        public void Prelievo(double importo)
        {
            if (!IsAperto)
            {
                throw new Exception("Il conto non è aperto.");
            }

            if (Saldo < importo)
            {
                throw new Exception("Saldo insufficiente per il prelievo.");
            }

            Saldo -= importo;
        }
    }
}