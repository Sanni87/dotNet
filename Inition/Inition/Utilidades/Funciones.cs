using Inition.Model.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Inition.Utilidades
{
    public class Funciones
    {
        public static bool IntersectPixels(IForma formaA, IForma formaB) 
        {

            // 1º buscamos las coordenadas del "rectángulo" de intersección
            var rectanguloA = formaA.Area;
            var rectanguloB = formaB.Area;


            //Este rectángulo viene dado por la intersección de los 2 rectángulos de cada figura
            float top = Math.Max(rectanguloA.Top, rectanguloB.Top);
            float bottom = Math.Min(rectanguloA.Bottom, rectanguloB.Bottom);
            float left = Math.Max(rectanguloA.Left, rectanguloB.Left);
            float right = Math.Min(rectanguloA.Right, rectanguloB.Right);

            Color[] dataA = formaA.Pixeles;
            Color[] dataB = formaB.Pixeles;

            if (dataA != null && dataB != null)
            {
                // Comprobamos cada punto del cuadro de intersección
                for (float y = top; y < bottom; y++)
                {
                    for (float x = left; x < right; x++)
                    {
                        // Obtenemos el color de cada forma en ese punto
                        Color colorA = dataA[(int)((x - rectanguloA.Left) +
                                    (y - rectanguloA.Top) * rectanguloA.Width)];
                        Color colorB = dataB[(int)((x - rectanguloB.Left) +
                                    (y - rectanguloB.Top) * rectanguloB.Width)];

                        // Si ninguno de los 2 pixeles son totalmente transparentes, hay interseccion
                        if (colorA.A != 0 && colorB.A != 0)
                        {
                            return true;
                        }
                    }
                }
            }

            // No hay intersecciones
            return false;
        }

        /// <summary>
        /// Obtiene el rectángulo más pequeño que cubre un dibujo
        /// </summary>
        /// <param name="dibujo">Dibujo del que se quiere obtener su rectángulo</param>
        /// <returns></returns>
        public static Rectangle ObtenerRectangulo(IForma forma)
        {
            //We now have our smallest possible rectangle for this texture
            return new Rectangle((int)forma.Posicion.X, (int)forma.Posicion.Y, forma.Dibujo.Bounds.Width, forma.Dibujo.Bounds.Height);
        }

        public static Rectangle ObtenerRectanguloMinimo(IForma forma)
        {
            //Obtenemos el array de 2 diensiones de los pixeles del dibujo
            Color[,] Colors = TextureTo2DArray(forma.Dibujo);

            //Inicializamos las variables
            int x1 = Int32.MaxValue, y1 = Int32.MaxValue;
            int x2 = Int32.MinValue, y2 = Int32.MinValue;

            for (int a = 0; a < forma.Dibujo.Width; a++)
            {
                for (int b = 0; b < forma.Dibujo.Height; b++)
                {
                    //Si encontramos un pixel que no es transparente, actualizamos los valores
                    if (Colors[a, b].A != 0)
                    {
                        if (x1 > a) x1 = a;
                        if (x2 < a) x2 = a;

                        if (y1 > b) y1 = b;
                        if (y2 < b) y2 = b;
                    }
                }
            }

            //We now have our smallest possible rectangle for this texture
            return new Rectangle((int)forma.Posicion.X, (int)forma.Posicion.Y, forma.Dibujo.Bounds.Width, forma.Dibujo.Bounds.Height);
        }

        /// <summary>
        /// Convierte un dibujo en una matriz 2D de colores
        /// </summary>
        /// <param name="texture"></param>
        /// <returns></returns>
        private static Color[,] TextureTo2DArray(Texture2D texture)
        {
            //Obtenemos el array de colores en 1D
            Color[] colors1D = new Color[texture.Width * texture.Height];
            texture.GetData(colors1D);

            //convertimos a 2 dimensiones
            Color[,] colors2D = new Color[texture.Width, texture.Height];
            for (int x = 0; x < texture.Width; x++)
                for (int y = 0; y < texture.Height; y++)
                    colors2D[x, y] = colors1D[x + y * texture.Width];

            return colors2D;
        }
    }
}
