using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Inition.Utilidades.Enumeradores;

namespace Inition.Utilidades.Comunes
{
    /// <summary>
    /// Clase que representa el movimiento de un objeto en un plano 2D
    /// </summary>
    public class Movimiento
    {
        /// <summary>
        /// Sentido del movimiento en el eje horizontal
        /// </summary>
        public SentidoHorizontal SentidoHorizontal { get; set; }

        /// <summary>
        /// Sentido del movimiento en el eje Vertical
        /// </summary>
        public SentidoVertical SentidoVertical { get; set; }

        /// <summary>
        /// Velocidad en el eje horizontal por ciclo
        /// </summary>
        public int VelocidadHorizontal { get; set; }

        /// <summary>
        /// Velocidad en el eje vertical por ciclo
        /// </summary>
        public int VelocidadVertical { get; set; }

        /// <summary>
        /// Sentido, dentro del eje horizontal, en el que se acelera
        /// </summary>
        public SentidoHorizontal SentidoAceleracionHorizontal { get; set; }

        /// <summary>
        /// Sentido, dentro del eje horizontal, en el que se acelera
        /// </summary>
        public SentidoVertical SentidoAceleracionVertical { get; set; }

        /// <summary>
        /// Aceleración en el eje horizontal por ciclo
        /// </summary>
        public int AceleracionHorizontal { get; set; }

        /// <summary>
        /// Aceleración en el eje vertical por ciclo
        /// </summary>
        public int AceleracionVertical { get; set; }

        /// <summary>
        /// Devuelve la cantidad de unidades a desplazar en el eje horizontal dependiendo del sentido y la velocidad
        /// </summary>
        /// <returns></returns>
        public int AMoverHorizontal()
        {
            return (int)this.SentidoHorizontal * (int)this.VelocidadHorizontal;
        }

        /// <summary>
        /// Devuelve la cantidad de unidades a desplazar en el eje vertical dependiendo del sentido y la velocidad
        /// </summary>
        /// <returns></returns>
        public int AMoverVertical()
        {
            return (int)this.SentidoVertical * (int)this.VelocidadVertical;
        }

        /// <summary>
        /// Aplica la aceleración en el eje horizontal, cambiando el sentido si es necesario
        /// </summary>
        public void AcelerarHorizontal()
        {
            int velocidadHorizontal = (int)this.VelocidadHorizontal + ((int)this.SentidoAceleracionHorizontal * (int)this.AceleracionHorizontal);
            if (velocidadHorizontal < 0) this.cambiarSentidoMovimientoHorizontal();
            this.VelocidadHorizontal = velocidadHorizontal < 0 ? (velocidadHorizontal * -1) : velocidadHorizontal;
        }

        /// <summary>
        /// Aplica la aceleración en el eje horizontal, cambiando el sentido si es necesario
        /// </summary>
        public void AcelerarVertical()
        {
            int velocidadVertical = this.VelocidadVertical + ((int)this.SentidoAceleracionVertical * this.AceleracionVertical);
            if (velocidadVertical < 0) this.cambiarSentidoMovimientoVertical();
            this.VelocidadVertical = velocidadVertical < 0 ? (velocidadVertical * -1) : velocidadVertical;
        }


        #region funciones privadas

        private void cambiarSentidoMovimientoHorizontal()
        {
            if (this.SentidoHorizontal == SentidoHorizontal.Izquierda)
            {
                this.SentidoHorizontal = SentidoHorizontal.Derecha;
            }
            else if (this.SentidoHorizontal == SentidoHorizontal.Derecha) 
            {
                this.SentidoHorizontal = SentidoHorizontal.Izquierda;
            }
        }

        private void cambiarSentidoMovimientoVertical()
        {
            if (this.SentidoVertical == SentidoVertical.Arriba)
            {
                this.SentidoVertical = SentidoVertical.Abajo;
            }
            else if (this.SentidoVertical == SentidoVertical.Abajo)
            {
                this.SentidoVertical = SentidoVertical.Arriba;
            }
        }
        #endregion

    }
}
