using System.Security.Cryptography.X509Certificates;

namespace VinFletchersArrows
{
    public enum ArrowHead { steel, wood, obsidian }
    public enum Fletching { plastic, turkey, goose }

    public class Arrow
    {
        private ArrowHead _arrowHead;
        private Fletching _fletching;
        private int _shaftLength;

        public ArrowHead ArrowHead
        {
            get { return _arrowHead; }
        }

        public Fletching Fletching
        {
            get { return _fletching; }
        }

        public int ShaftLength
        {
            get { return _shaftLength; }
        }

        public Arrow(ArrowHead arrowHead, Fletching fletching, int shaftLength)
        {
            this._arrowHead = arrowHead;
            this._fletching = fletching;
            this._shaftLength = shaftLength;
        }

        public float ArrowheadCost => _arrowHead switch
        {
            ArrowHead.steel => 10f,
            ArrowHead.wood => 3f,
            ArrowHead.obsidian => 5f,
            _ => 0f
        };
        public float FletchingCost => _fletching switch
        {
            Fletching.plastic => 1f,
            Fletching.turkey => 5f,
            Fletching.goose => 3f,
            _ => 0f
        };

        public float ShaftCost => _shaftLength * 0.05f;
        public float TotalCost() => ArrowheadCost + FletchingCost + ShaftCost;



    }

    internal class Program
    {
        static void Main(string[] args)
        {
            ArrowHead selectedArrowHead = ArrowHead.steel;
            Fletching selectedFletching = Fletching.plastic;
            int selectedShaftLength = 0;

            Console.Title = "Vin Fletcher's Arrow";
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Welcome to Vin Fletcher's Arrow Emporium!");
            Console.ForegroundColor = ConsoleColor.White;

            ArrowBuilder("Choose your arrowhead:",
                new string[] { "Steel", "Wood", "Obsidian" },
                choice => selectedArrowHead = (ArrowHead)choice);
            ArrowBuilder("Choose your fletching:",
                new string[] { "Plastic", "Turkey", "Goose" },
                choice => selectedFletching = (Fletching)choice);
            Console.Write("\nChoose your shaft length: (25-40) inches. ");
            int shaftLength = Convert.ToInt32(Console.ReadLine());
            if (shaftLength >= 25 && shaftLength <= 40)
            {
                selectedShaftLength = shaftLength;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid shaft length. Please enter a length between 25 and 40.");
                Console.ForegroundColor = ConsoleColor.White;
                return;
            }
            Arrow arrow = new Arrow(selectedArrowHead, selectedFletching, selectedShaftLength);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Calculating the cost of your {arrow.ArrowHead} arrow with {arrow.Fletching} fletching and a {arrow.ShaftLength}-inch shaft.");
            Console.Write("\n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"Arrowhead cost: {arrow.ArrowHead} - {arrow.ArrowheadCost} gold");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine($"Fletching cost: {arrow.Fletching} - {arrow.FletchingCost} gold");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"Shaft cost: {arrow.ShaftLength}-inch - {arrow.ShaftCost} gold");
            Console.Write($"\nThe total cost is: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($"{arrow.TotalCost()} gold");
            Console.ResetColor();

            void ArrowBuilder(string question, string[] options, Action<int> setChoice)
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
