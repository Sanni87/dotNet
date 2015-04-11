using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Inition.Model.Interfaces
{
    public interface IForma : IDibujable
    {
        /// <summary>
        /// Dibujo de la forma.
        /// </summary>
        Texture2D Dibujo { get; }

        /// <summary>
        /// Pixeles del dibujo
        /// </summary>
        Color[] Pixeles { get; }

        /// <summary>
        /// Posicion de la forma en el espacio
        /// </summary>
        Vector2 Posicion { get; }

        /// <summary>
        /// Indica el recuadro del área del dibujo, en formato adecuado para obtener sus medidas y proporciones
        /// </summary>
        Rectangle Area { get; }
    }
}
