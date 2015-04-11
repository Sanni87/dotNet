using Inition.Model.Interfaces;
using Inition.Utilidades;
using Inition.Utilidades.Comunes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Inition.Model.Elementos
{
    public abstract class Rectangulo : IColisionable
    {

        #region Miembros de la interfaz
        public Texture2D Dibujo { get; set; }

        public Vector2 Posicion { get; set; }

        public Rectangle Area {get; private set;}

        public Movimiento Movimiento { get; set; }

        public Color[] Pixeles 
        { 
            get 
            {
                Color[] colores = new Color[this.Dibujo.Width * this.Dibujo.Height];
                this.Dibujo.GetData(colores);

                return colores;
            } 
        }
        #endregion

        public Rectangulo()
        {

        }

        public Rectangulo(Texture2D pDibujo, Vector2 pPosicion)
        {
            this.Dibujo = pDibujo;
            this.Posicion = pPosicion;
            //this.Area = Funciones.ObtenerRectangulo(this.Dibujo);
        }

        public void Draw(ref SpriteBatch spriteBatch)
        {
            if (this.Dibujo != null && this.Posicion != null) 
            {
                spriteBatch.Draw(this.Dibujo, this.Posicion, Color.White);
                this.Area = Funciones.ObtenerRectangulo(this);
            }
        }


        public virtual void Update()
        {
            UpdateX();

            UpdateY();
        }

        public virtual bool Colisiona(IColisionable colisionable)
        {
            bool bColisiona = false;

            //Comprobación simple
            if (this.Area.Intersects(colisionable.Area))
            {
                bColisiona = true;
            }

            return bColisiona;
        }

        #region Funciones abstractas

        internal abstract void UpdateX();

        internal abstract void UpdateY();

        public abstract void ComprobarColision(IColisionable colisionable);

        public abstract void ReaccionarAColision(IColisionable colisionable);

        #endregion
    }
}
