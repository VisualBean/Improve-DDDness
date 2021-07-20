using System;
using System.Collections.Generic;

namespace Core.Improved
{
    public class Demon
    {
        private const int maxNameLength = 15;

        // Backing field for Enumerable API. - Underling although it only has 1 property, has domain rules.
        private readonly IList<Underling> underlings = new List<Underling>();

        // Private ctor means no direct creation of the object. - possibly has more validation concerns.
        private Demon(string name, ushort age, Power power)
        {
            // parameter validation close to object creation. - Business rules.
            if (string.IsNullOrWhiteSpace(name))
            {
                // Throwing means NO inconsistent states in our "domain" code.
                throw new ArgumentException($"'{nameof(name)}' cannot be null or whitespace.", nameof(name));
            }

            if (name.Length > maxNameLength)
            {
                throw new ArgumentException($"'{nameof(name)}' cannot be more than {maxNameLength} characters.", nameof(name));
            }

            Name = name;
            Age = age;
            Power = power;

            Console.WriteLine($"I {Name}, have returned!");
        }

        // Factory method for encapulating more complex creation logic. - Could be moved out for better dependency injection.
        public static Demon Summon(string name, ushort age, Power power)
        {
            return new Demon(name, age, power);
        }
        
        // Private setters for immutability.
        public string Name { get; private set; }

        public int Age { get; private set; }

        public bool HasHorns { get; private set; }
        
        // Power has been encapsulated to force a typed relationship between PowerName and PowerDamage.
        public Power Power { get; private set; }

        // IEnumerable does not expose the list API.
        public IEnumerable<Underling> Underlings => this.underlings;

        // Force domain rules for `adding` an underling.
        public void EnslaveUnderling(string name)
        {
            // Can be created due to being in the same assembly
            var underling = new Underling(name);
            if (underlings.Contains(underling))
            {
                return;
            }

            underlings.Add(underling);
        }

        public void GrowHorns()
        {
            HasHorns = true;
        }

        // Override `equals` to force equality on "name"
        public override bool Equals(object obj)
        {
            if (!(obj is Demon demon))
            {
                return false;
            }
            if (obj == null || !(obj is Demon))
            {
                return false;
            }
            if (ReferenceEquals(this, obj))
            {
                return true;
            }
            if (this.GetType() != obj.GetType())
            {
                return false;
            }

            return string.Equals(Name, demon.Name, StringComparison.InvariantCultureIgnoreCase);
        }

        // See equals.
        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

        // normally uses reference equality. Force use of Equals
        public static bool operator ==(Demon left, Demon right)
        {
            return Equals(left, right);
        }

        // normally uses reference equality. Force use of Equals
        public static bool operator !=(Demon left, Demon right)
        {
            return !Equals(left, right);
        }

        ~Demon()
        {
            Console.WriteLine("Nooo arrrrrgghhhhhh");
        }
    }
}