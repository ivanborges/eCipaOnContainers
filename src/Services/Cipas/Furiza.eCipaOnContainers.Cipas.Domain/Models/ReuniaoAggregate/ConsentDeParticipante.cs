namespace Furiza.eCipaOnContainers.Cipas.Domain.Models.ReuniaoAggregate
{
    public sealed class ConsentDeParticipante : Consent
    {
        private ConsentDeParticipante() : base() { }

        public ConsentDeParticipante(bool value, string justificativa) : base(value, justificativa) { }
    }
}