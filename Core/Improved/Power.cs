using System;

namespace Core.Improved
{
    public class Power
    {
        // Force strongly typed usage
        public static Power Fireball = new Power("Fireball", 600);
        public static Power Lightning = new Power("Lightning", 300);

        // Private ctor to not expose a creation API.
        private Power(string name, ushort damage)
        {
            // Complex argument validation.
            if (string.IsNullOrWhiteSpace(name))
            {
                // Throw to ensure no inconsistent states.
                throw new ArgumentException($"'{nameof(name)}' cannot be null or whitespace.", nameof(name));
            }

            Name = name;
            Damage = damage;
        }

        public int Damage { get; private set; }

        public string Name { get; private set; }

        // Override equals to force equality to be on `Name` and `Damage`
        public override bool Equals(object obj)
        {
            if (!(obj is Power power))
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

            return Name == power.Name && Damage == Damage;
        }

        // See Equals
        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Damage);
        }
    }
}
