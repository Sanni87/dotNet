using Inition.Model.Interfaces;
using Inition.Utilidades;
using Inition.Utilidades.Comunes;
using Inition.Utilidades.Enumeradores;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Inition.Model.Elementos
{
    public class RectanguloAutomatico : Rectangulo
    {

        /// <summary>
        /// Objeto que representa la colisión producida con otro objeto
        /// </summary>
        public Colision Colision { get; set; }

        public RectanguloAutomatico()
            : base()
        {
            this.Movimiento = new Movimiento 
            { 
                SentidoHorizontal = Utilidades.Enumeradores.SentidoHorizontal.Derecha,
                SentidoVertical = Utilidades.Enumeradores.SentidoVertical.Abajo,

                VelocidadHorizontal = 5,
                VelocidadVertical = 5,

                AceleracionHorizontal = 0,
                AceleracionVertical = 0
            };

            this.Colision = new Colision(this.Area);
        }

        public RectanguloAutomatico(Texture2D dibujo, Vector2 posicion) 
            : this()
        {
            this.Dibujo = dibujo;
            this.Posicion = posicion;
            
        }

        public override void Update()
        {
            this.Colision = new Colision(this.Area);

            base.Update();
        }

        internal override void UpdateX()
        {
            Vector2 vPosicion = this.Posicion;

            vPosicion.X += this.Movimiento.AMoverHorizontal();

            this.Posicion = vPosicion;
        }

        internal override void UpdateY()
        {
            var vPosicion = this.Posicion;
            vPosicion.Y += this.Movimiento.AMoverVertical();
            this.Posicion = vPosicion;
        }

        public override void ComprobarColision(IColisionable colisionable)
        {
            this.Colision.CalcularDireccionColision(colisionable.Area);
        }

        public override void ReaccionarAColision(IColisionable colisionable)
        {

            var vPosicion = this.Posicion;

            if (HayColisionIzquierda() && this.Movimiento.SentidoHorizontal == SentidoHorizontal.Izquierda)
            {
                this.Movimiento.SentidoHorizontal = SentidoHorizontal.Derecha;
                vPosicion.X += this.Movimiento.AMoverHorizontal();
            }
            else if (HayColisionDerecha() && this.Movimiento.SentidoHorizontal == SentidoHorizontal.Derecha)
            {
                this.Movimiento.SentidoHorizontal = SentidoHorizontal.Izquierda;
                vPosicion.X += this.Movimiento.AMoverHorizontal();
            }

            if (HayColisionArriba() && this.Movimiento.SentidoVertical == SentidoVertical.Arriba)
            {
                this.Movimiento.SentidoVertical = SentidoVertical.Abajo;
                vPosicion.Y += this.Movimiento.AMoverVertical();
            }
            else if (HayColisionAbajo() && this.Movimiento.SentidoVertical == SentidoVertical.Abajo)
            {
                this.Movimiento.SentidoVertical = SentidoVertical.Arriba;
                vPosicion.Y += this.Movimiento.AMoverVertical();
            }

            this.Posicion = vPosicion;
        }

        private bool HayColisionAbajo()
        {
            return this.Colision.VectorColision.Y > 0;
        }

        private bool HayColisionArriba()
        {
            return this.Colision.VectorColision.Y < 0;
        }

        private bool HayColisionDerecha()
        {
            return this.Colision.VectorColision.X > 0;
        }

        private bool HayColisionIzquierda()
        {
            return this.Colision.VectorColision.X < 0;
        }
    }
}
