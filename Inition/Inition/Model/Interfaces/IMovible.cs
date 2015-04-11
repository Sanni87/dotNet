using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Inition.Utilidades.Comunes;

namespace Inition.Model.Interfaces
{
    public interface IMovible
    {
        /// <summary>
        /// Propiedad que representa el movimiento del objeto
        /// </summary>
        Movimiento Movimiento { get; }
    }
}
