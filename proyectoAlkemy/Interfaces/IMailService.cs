using proyectoAlkemy.Models;

namespace proyectoAlkemy.Interfaces
{
    public interface IMailService
    {
        /// <summary>
        /// Envia Emails a un username particular
        /// </summary>
        /// <param name="email"></param>
        /// <param name="username"></param>
        /// <returns></returns>
        Task SendEmail(User user);
    }
}
