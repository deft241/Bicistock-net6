using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bicistock.Data.Interfaces.Repositories
{
    public interface IUserRepository
    {
        /// <summary>
        /// Get a single user from Database
        /// </summary>
        /// <returns></returns>
        DataTable GetUser(string userName);

        /// <summary>
        /// Get all users
        /// </summary>
        /// <returns></returns>
        DataTable GetAll(string userName);

        /// <summary>
        /// Create a new User
        /// </summary>
        /// <returns></returns>
        DataTable CreateUser(string userName, string password, string dni, string name, string surnames, int age, string phone, string verified, byte idRole);

        /// <summary>
        /// Delete user
        /// </summary>
        /// <returns></returns>
        DataTable DeleteUser(string userName);

        /// <summary>
        /// Activate a User
        /// </summary>
        /// <returns></returns>
        DataTable ActivateUser(string userName);

        /// <summary>
        /// Get if a user is verified
        /// </summary>
        /// <returns></returns>
        DataTable GetVerified(string userName);
    }
}
