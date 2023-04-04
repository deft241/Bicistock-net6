using System.Data;

namespace Bicistock.Common.Models
{
    public class CS_Usuario
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Dni { get; set; }
        public string Name { get; set; }
        public string Surnames { get; set; }
        public int Age { get; set; }
        public string Phone { get; set; }
        public string Verified { get; set; }
        public byte Role { get; set; }


        public CS_Usuario()
        {

        }

        public CS_Usuario(DataRow fila)
        {
            UserName = fila.Field<string>(0);
            Password = fila.Field<string>(1);
            Dni = fila.Field<string>(2);
            Name = fila.Field<string>(3);
            Surnames = fila.Field<string>(4);
            Age = fila.Field<int>(5);
            Phone = fila.Field<string>(6);
            Verified = fila.Field<string>(7);
            Role = fila.Field<byte>(8);
        }




    }
}