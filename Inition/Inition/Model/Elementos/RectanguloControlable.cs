using Inition.Model.Interfaces;
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
    public class RectanguloControlable : Rectangulo
    {

        /// <summary>
        /// propiedad que almacena de forma temporal la posición previa al movimiento del objeto
        /// </summary>
        private Vector2 _posicionAnterior;

        /// <summary>
        /// True: el objeto se está controlando actualmente.
        /// False: el objeto no se está controlando actualmente.
        /// </summary>
        public bool Controlado { get; set; }

        /// <summary>
        /// Objeto que representa la colisión producida con otro objeto
        /// </summary>
        public Colision Colision { get; set; }

        public RectanguloControlable()
            : base()
        {
            this.Movimiento = new Movimiento 
            { 
                SentidoHorizontal = SentidoHorizontal.Ninguno,
                SentidoVertical = SentidoVertical.Ninguno,

                VelocidadHorizontal = 5,
                VelocidadVertical = 5,

                AceleracionHorizontal = 0,
                AceleracionVertical = 0
            };

            this._posicionAnterior = default(Vector2);
            this.Colision = new Colision(this.Area);
            this.Controlado = false;
        }

        public RectanguloControlable(Texture2D dibujo, Vector2 posicion) 
            : this()
        {
            this.Dibujo = dibujo;
            this.Posicion = posicion;
        }

        public override void Update()
        {
            if (this.Controlado)
            {
                this.Colision = new Colision(this.Area);

                this._posicionAnterior = new Vector2(this.Posicion.X, this.Posicion.Y);

                base.Update();
            }
        }

        internal override void UpdateX()
        {
            var pad = PadInput.Input;

            //Movemos X
            this.Movimiento.SentidoHorizontal = pad.MovimientoHorizontal;

            var vPosicion = this.Posicion;
            vPosicion.X += this.Movimiento.AMoverHorizontal();
            this.Posicion = vPosicion;
        }

        internal override void UpdateY()
        {
            var pad = PadInput.Input;

            //Movemos Y
            this.Movimiento.SentidoVertical = pad.MovimientoVertical;

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
                vPosicion.X = this._posicionAnterior.X;
            }
            else if (HayColisionDerecha() && this.Movimiento.SentidoHorizontal == SentidoHorizontal.Derecha)
            {
                vPosicion.X = this._posicionAnterior.X;
            }

            if (HayColisionArriba() && this.Movimiento.SentidoVertical == SentidoVertical.Arriba)
            {
                vPosicion.Y = this._posicionAnterior.Y;
            }
            else if (HayColisionAbajo() && this.Movimiento.SentidoVertical == SentidoVertical.Abajo)
            {
                vPosicion.Y = this._posicionAnterior.Y;
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
