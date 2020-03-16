namespace Furiza.eCipaOnContainers.Cipas.Domain.Models.ReuniaoAggregate
{
    public sealed class ConsentDeAusente : Consent
    {
        private ConsentDeAusente() : base() { }

        public ConsentDeAusente(bool value, string justificativa) : base(value, justificativa) { }
    }
}