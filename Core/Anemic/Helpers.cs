namespace Core.Anemic
{
    public static class Helpers
    {
        // Domain rules far away from domain object. = more cognitive load.
        public static bool IsValid(this Demon demon)
        {
            // IsValid pattern opens up for inconsistent data to flow if developers forget to call it.
            if (demon.Age <= 0
                || string.IsNullOrWhiteSpace(demon.Name)
                || demon.Name.Length > 15)
            {
                return false;
            }

            return true;
        }
    }
}
