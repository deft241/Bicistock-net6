using System.Data;

namespace Bicistock.Common.Models
{
    public class CS_Marca
    {
        public int Id { get; set; }
        public string Name { get; set; }


        public CS_Marca()
        {

        }

        public CS_Marca(DataRow fila)
        {
            Id = fila.Field<int>("ID");
            Name = fila.Field<string>("NAME");
        }
    }
}
