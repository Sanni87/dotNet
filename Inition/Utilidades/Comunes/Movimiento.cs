using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilidades.Enumeradores;

namespace Utilidades.Comunes
{
    public class Movimiento
    {
        /// <summary>
        /// Sentido del movimiento en el eje horizontal
        /// </summary>
        public SentidoHorizontal SentidoHorizontal { get; set; }

        /// <summary>
        /// Sentido del movimiento en el eje Vertical
        /// </summary>
        public SentidoVertical SentidoVertical { get; set; }

        /// <summary>
        /// Velocidad en el eje horizontal por ciclo
        /// </summary>
        public int VelocidadHorizontal { get; set; }

        /// <summary>
        /// Velocidad en el eje vertical por ciclo
        /// </summary>
        public int VelocidadVertical { get; set; }

        /// <summary>
        /// Sentido, dentro del eje horizontal, en el que se acelera
        /// </summary>
        public SentidoHorizontal SentidoAceleracionHorizontal { get; set; }
    }
}
