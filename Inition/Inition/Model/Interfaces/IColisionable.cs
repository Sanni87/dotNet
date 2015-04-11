using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

using Inition.Utilidades.Comunes;

namespace Inition.Model.Interfaces
{
    /// <summary>
    /// Interfaz que representa una forma que puede colisionar con otras formas
    /// </summary>
    public interface IColisionable : IForma, IMovible
    {

        /// <summary>
        /// Función que indica si el objeto colisiona con otro
        /// </summary>
        /// <param name="colisionable">Objeto con el que puede colisionar la instancia</param>
        /// <returns>true si colisiona. False si no</returns>
        bool Colisiona(IColisionable colisionable);

        /// <summary>
        /// Realiza las comprobaciones necesarias previas a corregir la colisión.
        /// </summary>
        /// <param name="colisionable"></param>
        void ComprobarColision(IColisionable colisionable);

        /// <summary>
        /// Reacción del objeto al colisionar con otro
        /// </summary>
        /// <param name="colisionable">Objeto con el que colisiona la instancia</param>
        void ReaccionarAColision(IColisionable colisionable);
    }
}
