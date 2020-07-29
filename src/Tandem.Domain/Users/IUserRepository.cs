using System.Threading.Tasks;

namespace Tandem.Domain.Users
{
    /// <summary>
    /// Interface for types that will provide persistent storage access for users.
    /// </summary>
    public interface IUserRepository
    {
        /// <summary>
        /// Saves the supplied <paramref name="user"/> to persistent storage.
        /// </summary>
        /// <param name="user">
        /// Required user to save.
        /// </param>
        Task SaveUserAsync(User user);
    }
}