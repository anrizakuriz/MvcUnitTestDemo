using MvcUnitTestDemo.Models;

namespace MvcUnitTestDemo.Services
{
    public interface IUserService
    {
        /// <summary>
        /// get All Users
        /// </summary>
        Task<List<User>> GetAllUsers();
        /// <summary>
        /// Retrieves a user by their ID.
        /// </summary>
        /// <param name="id">The ID of the user to retrieve.</param>
        /// <returns>The user with the specified ID, or null if not found.</returns>
        Task<User> GetUserById(int id);

        /// <summary>
        /// Adds a new user.
        /// </summary>
        /// <param name="user">The user to add.</param>
        Task AddUser(User user);
        /// <summary>
        /// Updates an existing user.
        /// </summary>
        /// <param name="user">The user with updated information.</param>
        void UpdateUser(User user);
        /// <summary>
        /// Deletes a user by their ID.
        /// </summary>
        /// <param name="id">The ID of the user to delete.</param>
        void DeleteUser(int id);
    }

}
