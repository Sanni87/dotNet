using Inition.Model.Elementos;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Inition.Model.Factory
{
    public class RectanguloFactory
    {

        public static RectanguloAutomatico CrearRectanguloAutomatico(GraphicsDeviceManager graphics, int ancho, int alto, Color color, float posicionX = 0, float posicionY = 0)
        {
            Texture2D dibujo = new Texture2D(graphics.GraphicsDevice, ancho, alto);

            var colores = new Color[ancho * alto];
            for (int i = 0; i < colores.Length; ++i) colores[i] = color;
            dibujo.SetData(colores);

            Vector2 posicion = new Vector2(posicionX, posicionY);

            return new RectanguloAutomatico(dibujo, posicion);
        }

        public static RectanguloControlable CrearRectanguloMovible(GraphicsDeviceManager graphics, int ancho, int alto, Color color, float posicionX = 0, float posicionY = 0)
        {
            Texture2D dibujo = new Texture2D(graphics.GraphicsDevice, ancho, alto);

            var colores = new Color[ancho * alto];
            for (int i = 0; i < colores.Length; ++i) colores[i] = color;
            dibujo.SetData(colores);

            Vector2 posicion = new Vector2(posicionX, posicionY);

            return new RectanguloControlable(dibujo, posicion);
        }

        public static Pared CrearPared(GraphicsDeviceManager graphics, int ancho, int alto, Color color, float posicionX = 0, float posicionY = 0)
        {
            Texture2D dibujo = new Texture2D(graphics.GraphicsDevice, ancho, alto);

            var colores = new Color[ancho * alto];
            for (int i = 0; i < colores.Length; ++i) colores[i] = color;
            dibujo.SetData(colores);

            Vector2 posicion = new Vector2(posicionX, posicionY);

            return new Pared(dibujo, posicion);
        }
    }
}
