using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Inition.Model.Interfaces
{
    public interface IDibujable
    {
        /// <summary>
        /// Función que actualiza el estado el objeto
        /// </summary>
        void Update();

        /// <summary>
        /// Función que dibuja el objeto en el SpriteBatch
        /// </summary>
        /// <param name="spriteBatch"> Clase encargada del dibujado del objeto </param>
        void Draw(ref SpriteBatch spriteBatch);
    }
}
