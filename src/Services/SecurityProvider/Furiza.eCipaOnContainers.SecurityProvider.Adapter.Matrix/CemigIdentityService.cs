using Furiza.eCipaOnContainers.SecurityProvider.Core.Services;
using System.Threading.Tasks;

namespace Furiza.eCipaOnContainers.SecurityProvider.Adapter.Matrix
{
    internal class CemigIdentityService : ICemigIdentityService
    {
        public async Task<bool> VerificarSeEUmaMatriculaValidaAsync(string login)
        {
            //TODO: implementar.

            await Task.Delay(1);

            return false;
        }

        public async Task<bool> VerificarCredenciaisAsync(string login, string password)
        {
            //TODO: implementar.

            await Task.Delay(1);

            return false;
        }        
    }
}