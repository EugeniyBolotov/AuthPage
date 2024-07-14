using AuthPage.Models;
namespace AuthPage.Abstractions
{
    public interface IAuthenticationService
    {
        User User { get; }
        Task Initialize();
        Task Login(string username, string password);
        Task Logout();
    }
}
