using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilidades.Enumeradores
{
    /// <summary>
    /// Enumerador para indicar hacia donde se mueve un objeto en el eje horizontal
    /// </summary>
    public enum SentidoHorizontal : int
    {
        Izquierda = -1,
        Ninguno = 0,
        Derecha = 1
    }

    /// <summary>
    /// Enumerador para indicar hacia donde se mueve un objeto en el eje vertical
    /// </summary>
    public enum SentidoVertical : int
    {
        Arriba = -1,
        Ninguno = 0,
        Abajo = 1
    }
}
