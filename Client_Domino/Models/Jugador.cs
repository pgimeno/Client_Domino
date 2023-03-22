using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client_Domino.Models
{
    public class Jugador
    {
        public int Numero { get; set; }
        public string Nom { get; set; }
        public List<string> MaJugador { get; set; }
        public bool EnTorn { get; set; }
        public string ConnectedToString { get; set; }

        public Jugador(string nomJugador, string connectionString)
        {
            Nom = nomJugador;
            ConnectedToString = connectionString;

        }
    }
}
