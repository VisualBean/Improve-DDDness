namespace Core.Anemic
{
    public class DemonService
    {
        public Demon CreateDemon(
            string name,
            int age,
            bool hasHorns,
            string powerName,
            int powerDamage)
        {
            // Create demon...
            var newDemon = new Demon
            {
                Name = name,
                Age = age,
                HasHorns = hasHorns,
                PowerName = powerName,
                PowerDamage = powerDamage,
            };

            // Check validity
            if (newDemon.IsValid())
            {
                return newDemon;
            }

            return null;
        }
    }
}
