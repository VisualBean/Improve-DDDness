using System;

namespace Core.Improved
{
    // Encapsulated the `string` due to the rule of invariants.
    public class Underling
    {
        // Internal to not expose creation through the publicly exposed API, Creation is now done through the Aggregate
        internal Underling(string name)
        {
            // Domain rules.
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException($"'{nameof(name)}' cannot be null or whitespace.", nameof(name));
            }

            Name = name;
        }

        public string Name { get; private set; }

        // override Equals to force name equality comparison.
        public override bool Equals(object obj)
        {
            if (!(obj is Underling underling))
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

            return string.Equals(Name, underling.Name, StringComparison.InvariantCultureIgnoreCase);
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    }
}
