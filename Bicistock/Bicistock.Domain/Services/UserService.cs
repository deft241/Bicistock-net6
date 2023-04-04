using Bicistock.Common.Models;
using Bicistock.Data.Data.Repositories;
using Capa_Soporte.Helpers;
using System.Data;

namespace Bicistock.Domain.Services
{
    public class UserService
    {
        public User MostrarUsuario(string UserName)
        {
            Logger.Logger logger = new Logger.Logger();
            UserRepository accesoBD = new UserRepository();

            User UserEntity;

            DataTable datos = new DataTable();

            datos = accesoBD.MostrarUsuario(UserName);


            if (datos.Rows.Count == 0)
            {
                UserEntity = new User();
                UserEntity.UserName = null;
                return UserEntity;
            }
            else
            {
                UserEntity = new User(datos.Rows[0]);
                return UserEntity;
            }

        }

        public List<User> MostrarUsuarios()
        {
            UserRepository accesoBD = new UserRepository();
            List<User> UserList = new List<User>();
            DataTable datos = new DataTable();

            datos = accesoBD.MostrarTodos();
            foreach (DataRow item in datos.Rows)
            {
                UserList.Add(new User(item));
            }
            return UserList;
        }

        public void CrearUsuario(string username, string password, string Dni, string name, string surnames, int age,
            string phone, string verified, byte idPermission)
        {
            UserRepository accesoBD = new UserRepository();


            accesoBD.Insertar(username, password, Dni, name, surnames, age, phone, verified, idPermission);
        }


        public void ActivateUser(string username)
        {
            UserRepository accesoBD = new UserRepository();

            accesoBD.ActivateUser(username);
        }

        public bool IsVerified(string username)
        {
            UserRepository accesoBD = new UserRepository();

            if (string.IsNullOrEmpty(username))
            {
                return false;
            }

            if (accesoBD.GetVerified(username) == "T")
            {
                return true;
            }

            return false;
        }


        public bool LoginValidator(string username, string password)
        {
            //Check any null parameter
            if (username == null || username == string.Empty || password == null || password == string.Empty)
            {
                return false;
            }
            else
            {
                //Create new user entity
                User userEntity = MostrarUsuario(username);

                //Decrypt Password
                if (userEntity.Password == Encrypt.GetSHA256(password))
                {
                    //Authorized
                    return true;
                }
                else
                {
                    //No match
                    return false;
                }
            }


        }

    }
}
