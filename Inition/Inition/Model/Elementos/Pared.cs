using Inition.Utilidades.Comunes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Inition.Model.Elementos
{
    /// <summary>
    /// Clase que representa una pared en el juego. Un rectángulo que no se mueve
    /// </summary>
    public class Pared : Rectangulo
    {
        public Pared(Texture2D dibujo, Vector2 posicion) 
            : base(dibujo, posicion)
        {
            this.Movimiento = new Movimiento 
            { 
                SentidoHorizontal = Utilidades.Enumeradores.SentidoHorizontal.Ninguno,
                SentidoVertical = Utilidades.Enumeradores.SentidoVertical.Ninguno
            };
        }

        internal override void UpdateX()
        {
        }

        internal override void UpdateY()
        {
        }

        public override void ComprobarColision(Interfaces.IColisionable colisionable)
        {
        }

        public override void ReaccionarAColision(Interfaces.IColisionable colisionable)
        {
        }
    }
}
