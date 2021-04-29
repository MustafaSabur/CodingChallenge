using System;
namespace DataAccessLayer
{
    public interface IValidateRepository
    {

        int AttemptsAvailable();

        void IncrementAttempts();

        void ResetAttempts();
    }
}
