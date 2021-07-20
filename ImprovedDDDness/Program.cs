using System.Linq;
using Core;
namespace ImprovedDDDness.Implementation
{
    class Program
    {
        static void Main(string[] args)
        {
                
            /// ------------------
            /// Anemic model usage
            /// ------------------
            
            // No enforcement of domain rules without knowing exactly which classes to call.
            var demon = new Core.Anemic.Demon();
            demon.Age = -134;
            demon.HasHorns = true;
            demon.HasHorns = false;
            demon.Underlings = null;
            demon.Underlings.Add("Eric");





            /// -------------------------------
            /// Improved DDDNess (good old OOP)
            /// -------------------------------

            // Force creation with arguments.
            // Power has been encapsulated to ensure a typed relationship between damage and name.
            var baal = Core.Improved.Demon.Summon("baal", 666, Core.Improved.Power.Fireball);

            // Use ubiquitos language and encapsulate adding items to the list to enforce domain rules.
            baal.EnslaveUnderling("Eric");
        }
    }
}
