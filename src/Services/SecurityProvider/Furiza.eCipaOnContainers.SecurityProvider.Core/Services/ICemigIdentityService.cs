using System.Threading.Tasks;

namespace Furiza.eCipaOnContainers.SecurityProvider.Core.Services
{
    public interface ICemigIdentityService
    {
        /// <summary>
        /// Verifica se o login informado está em um formato válido de matrícula de acordo com as regras da Cemig. Exemplo: C056232 para empregado próprio ou E208842 para terceirizado.
        /// </summary>
        /// <param name="login">Login do usuário.</param>
        /// <returns>True caso esteja em um formato válido, do contrário, False.</returns>
        Task<bool> VerificarSeEUmaMatriculaValidaAsync(string login);

        /// <summary>
        /// Verifica se o login e senha informados são credenciais válidas de acordo com o provedor de identidade principal da Cemig.
        /// </summary>
        /// <param name="login">Login do usuário.</param>
        /// <param name="password">Senha do usuário.</param>
        /// <returns>True caso seja uma credencial válida, do contrário, False.</returns>
        Task<bool> VerificarCredenciaisAsync(string login, string password);
    }
}