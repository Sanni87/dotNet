using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Inition.Utilidades.Enumeradores;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace Inition
{
    /// <summary>
    /// Esta clase controla qué botón está pulsado, independientemente de si el usuario está usando el teclado o un gamepad.
    /// </summary>
    public class PadInput
    {
        #region Singleton
        /// <summary>
        /// Sólo hay una instancia de pad
        /// </summary>
        private static PadInput _padInput;


        /// <summary>
        /// La constructora es privada, para evitar que se creen instancias
        /// </summary>
        private PadInput()
        {

        }

        /// <summary>
        /// Creamos una propiedad readonly para obtener la instancia accesible
        /// </summary>
        public static PadInput Input 
        { 
            get 
            {
                if (_padInput == null)
                {
                    _padInput = new PadInput();
                }

                return _padInput;
            }
        }
        #endregion

        /// <summary>
        /// Indica si hay que moverse en sentido horizontal y hacia donde
        /// </summary>
        public SentidoHorizontal MovimientoHorizontal { get; private set; }

        /// <summary>
        /// Indica si hay que moverse en sentido vertical y hacia donde
        /// </summary>
        public SentidoVertical MovimientoVertical { get; private set; }

        /// <summary>
        /// True: botón de acción pulsado
        /// False: botón de acción no pulsado
        /// </summary>
        public bool Accion { get; private set; }

        /// <summary>
        /// True: botón de salir pulsado
        /// False: Botón de salir no pulsado
        /// </summary>
        public bool Salir { get; private set; }


        public void Update()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                this.MovimientoVertical = SentidoVertical.Arriba;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                this.MovimientoVertical = SentidoVertical.Abajo;
            }
            else this.MovimientoVertical = SentidoVertical.Ninguno;


            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                this.MovimientoHorizontal = SentidoHorizontal.Izquierda;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                this.MovimientoHorizontal = SentidoHorizontal.Derecha;
            }
            else this.MovimientoHorizontal = SentidoHorizontal.Ninguno;

            this.Accion = Keyboard.GetState().IsKeyDown(Keys.Enter);

            this.Salir = GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape);
        }
        
    }
}
