namespace DespesasApi.Domain.Validation
{
    public class DomainExceptionValidation : Exception
    {
        public DomainExceptionValidation(string error) : base(error)
        {

        }

        public static void When(bool hasError, string messageError)
        {
            if(hasError)
                throw new DomainExceptionValidation(messageError);
        }
    }
}
