using Bicistock.Common.Models;
using Bicistock.Data.Data;
using Capa_Soporte.Helpers;
using System.Data;

namespace Bicistock.Domain
{
    public class CN_Usuario
    {
        public CS_Usuario MostrarUsuario(string UserName)
        {
            Logger.Logger logger = new Logger.Logger();
            CD_Usuarios accesoBD = new CD_Usuarios();

            CS_Usuario UserEntity;

            DataTable datos = new DataTable();

            datos = accesoBD.MostrarUsuario(UserName);


            if (datos.Rows.Count == 0)
            {
                UserEntity = new CS_Usuario();
                UserEntity.UserName = null;
                return UserEntity;
            }
            else
            {
                UserEntity = new CS_Usuario(datos.Rows[0]);
                return UserEntity;
            }

        }

        public List<CS_Usuario> MostrarUsuarios()
        {
            CD_Usuarios accesoBD = new CD_Usuarios();
            List<CS_Usuario> UserList = new List<CS_Usuario>();
            DataTable datos = new DataTable();

            datos = accesoBD.MostrarTodos();
            foreach (DataRow item in datos.Rows)
            {
                UserList.Add(new CS_Usuario(item));
            }
            return UserList;
        }

        public void CrearUsuario(string username, string password, string Dni, string name, string surnames, int age,
            string phone, string verified, byte idPermission)
        {
            CD_Usuarios accesoBD = new CD_Usuarios();


            accesoBD.Insertar(username, password, Dni, name, surnames, age, phone, verified, idPermission);
        }


        public void ActivateUser(string username)
        {
            CD_Usuarios accesoBD = new CD_Usuarios();

            accesoBD.ActivateUser(username);
        }

        public bool IsVerified(string username)
        {
            CD_Usuarios accesoBD = new CD_Usuarios();

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
                CS_Usuario userEntity = MostrarUsuario(username);

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
