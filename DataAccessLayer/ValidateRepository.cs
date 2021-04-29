using System;
namespace DataAccessLayer
{
    public class ValidateRepository : IValidateRepository
    {
        public ValidateRepository()
        {
        }

        public int AttemptsAvailable()
        {
            throw new NotImplementedException();
        }


        public void IncrementAttempts()
        {
            throw new NotImplementedException();
        }

        public void ResetAttempts()
        {
            throw new NotImplementedException();

        }
    }
}
