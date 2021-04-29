namespace DataAccessLayer
{
    public class ValidateRepository : IValidateRepository
    {
        public static int attemps = 0;
        public static int maxAttemps = 3;

        public ValidateRepository()
        {
        }

        public int AttemptsAvailable()
        {
            var availableAttemps = maxAttemps - attemps;
            if(availableAttemps < 0)
            {
                availableAttemps = 0;
            }

            return availableAttemps;
        }


        public void IncrementAttempts()
        {
            attemps++;
        }

        public void ResetAttempts()
        {
            attemps = 0;

        }
    }
}
