using System.Threading.Tasks;
using PublishingTest.Models.Users;

namespace PublishingTest.Services.Users;

public interface IUserService
{
    /// <summary>
    /// This can only be done by the logged in user.
    /// </summary>
    Task<User> Create(UserCreateParams parameters);

    /// <summary>
    /// Get user by user name
    /// </summary>
    Task<User> Retrieve(UserRetrieveParams parameters);

    /// <summary>
    /// This can only be done by the logged in user.
    /// </summary>
    Task Update(UserUpdateParams parameters);

    /// <summary>
    /// This can only be done by the logged in user.
    /// </summary>
    Task Delete(UserDeleteParams parameters);

    /// <summary>
    /// Creates list of users with given input array
    /// </summary>
    Task<User> CreateWithList(UserCreateWithListParams parameters);

    /// <summary>
    /// Logs user into the system
    /// </summary>
    Task<string> Login(UserLoginParams parameters);

    /// <summary>
    /// Logs out current logged in user session
    /// </summary>
    Task Logout(UserLogoutParams parameters);
}
