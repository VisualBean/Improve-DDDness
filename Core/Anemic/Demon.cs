using System.Collections.Generic;

namespace Core.Anemic
{
    // No ctor = public empty ctor. No enforcment of domain rules.
    public class Demon
    {
        // Public setters expose mutability and communicates acceptance of changing properties at runtime.
        public int Age { get; set; }

        public bool HasHorns { get; set; }

        public string Name { get; set; }

        // Properties commonly used together, but no typed relationship, adds cognitive load and reduces chance of adhering to domain rules.
        public int PowerDamage { get; set; }

        public string PowerName { get; set; }

        // Exposed `List` API allows for changing list items at runtime with no validation. 
        public List<string> Underlings { get; set; }
    }
}