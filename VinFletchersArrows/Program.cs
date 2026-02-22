namespace VinFletchersArrows
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Vin Fletcher's Arrow";
            Console.WriteLine("Welcome to Vin Fletcher's Arrow Emporium!");
            Arrow Arrow = new Arrow();
            ArrowBuilder("Choose your arrowhead:", new string[] {"Steel", "Wood", "Obsidian"}, choice => Arrow.ArrowHead = (Arrow.ArrowHead)choice);
            Arrowbuilder("Choose your fletching:", new string[] {"Plastic", "Turkey", "Goose"}, choice => Arrow.Fletching = (Arrow.Fletching)choice);
            

            void ArrowBuilder (string question, string[] options, Action<int> setChoice)
            {
                bool validChoice = true;
                while (validChoice)
                {
                    Console.WriteLine();
                    Console.WriteLine(question);
                    for (int i = 0; i < options.Length; i++)
                    {
                        Console.WriteLine($"{i + 1}. {options[i]}");
                    }
                    ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                    if (keyInfo.KeyChar >= '1' && keyInfo.KeyChar <= (char)('0' + options.Length))
                    {
                        setChoice(keyInfo.KeyChar - '1');
                        validChoice = false;
                    }
                    else
                    {
                        Console.WriteLine("Invalid choice.");
                    }
                }
            }
        }

        public class Arrow
        {
            public string arrowHead { get; set; }
            public string fletching { get; set; }
            public int shaftLength { get; set; }

            public Arrow(string arrowHead, string fletching, int shaftLength)
            {
                this.arrowHead = arrowHead;
                this.fletching = fletching;
                this.shaftLength = shaftLength;
            }

            enum ArrowHead { steel, wood, obsidian }
            enum Fletching { plastic, turkey, goose }
            
        }
    }
}
