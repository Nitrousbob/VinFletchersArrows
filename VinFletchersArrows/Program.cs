namespace VinFletchersArrows
{
    public enum ArrowHead { steel, wood, obsidian }
    public enum Fletching { plastic, turkey, goose }

    public class Arrow
    {
        public ArrowHead arrowHead { get; set; }  //this is how we use enums
        public Fletching fletching { get; set; }
        public int shaftLength { get; set; }

        public Arrow(ArrowHead arrowHead, Fletching fletching, int shaftLength)
        {
            this.arrowHead = arrowHead;
            this.fletching = fletching;
            this.shaftLength = shaftLength;
        }

        public Arrow() { }

        public float ArrowheadCost => arrowHead switch
        {
            ArrowHead.steel => 10f,
            ArrowHead.wood => 3f,
            ArrowHead.obsidian => 5f,
            _ => 0f
        };
        public float FletchingCost => fletching switch
        {
            Fletching.plastic => 1f,
            Fletching.turkey => 5f,
            Fletching.goose => 3f,
            _ => 0f
        };
        
        public float ShaftCost => shaftLength * 0.05f;
        public float TotalCost() => ArrowheadCost + FletchingCost + ShaftCost;
        
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Vin Fletcher's Arrow";
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Welcome to Vin Fletcher's Arrow Emporium!");
            Console.ForegroundColor = ConsoleColor.White;
            Arrow arrow = new Arrow();
            ArrowBuilder("Choose your arrowhead:",
                new string[] {"Steel", "Wood", "Obsidian"},
                choice => arrow.arrowHead = (ArrowHead)choice);
            ArrowBuilder("Choose your fletching:",
                new string[] {"Plastic", "Turkey", "Goose"},
                choice => arrow.fletching = (Fletching)choice);
            Console.Write("\nChoose your shaft length: (25-40) inches. ");
            int shaftLength = Convert.ToInt32(Console.ReadLine());
            if (shaftLength >= 25 && shaftLength <= 40)
            {
                arrow.shaftLength = shaftLength;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid shaft length. Please enter a length between 25 and 40.");
                Console.ForegroundColor = ConsoleColor.White;
                return;
            }
            Console.ForegroundColor= ConsoleColor.Cyan;
            Console.WriteLine($"Calculating the cost of your {arrow.arrowHead} arrow with {arrow.fletching} fletching and a {arrow.shaftLength}-inch shaft.");
            Console.Write("\n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"Arrowhead cost: {arrow.arrowHead} - {arrow.ArrowheadCost} gold");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine($"Fletching cost: {arrow.fletching} - {arrow.FletchingCost} gold");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"Shaft cost: {arrow.shaftLength}-inch - {arrow.ShaftCost} gold");
            Console.Write($"\nThe total cost is: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($"{arrow.TotalCost()} gold");
            Console.ResetColor();

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
    }
}
