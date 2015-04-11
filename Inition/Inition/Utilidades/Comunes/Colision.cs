using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Inition.Utilidades.Enumeradores;

namespace Inition.Utilidades.Comunes
{
    public class Colision
    {
        /// <summary>
        /// Atributo privado para calcular por dónde hay colision.
        /// -------------
        /// | 0 | 1 | 2 |
        /// | 3 | X | 4 |
        /// | 5 | 6 | 7 |
        /// -------------
        /// </summary>
        private List<AreaParcialColision> _areasParcialesColision;

        /// <summary>
        /// Atributo privado con el cálculo de desde dónde viene la colisión.
        /// Si el eje X es negativo, la colisión viene de la izquierda, si es positivo, viene de la derecha.
        /// Si el eje Y es negativo, la colisión viene de arriba, si es positivo, viene de abajo.
        /// </summary>
        private Vector2 _vectorColision;

        /// <summary>
        /// Propiedad de sólo lectura que indica desde dónde viene la colisión.
        /// Si el eje X es negativo, la colisión viene de la izquierda, si es positivo, viene de la derecha.
        /// Si el eje Y es negativo, la colisión viene de arriba, si es positivo, viene de abajo.
        /// </summary>
        public Vector2 VectorColision 
        {
            get 
            {
                return _vectorColision;
            }
        }

        /// <summary>
        /// Area de colisión total
        /// </summary>
        public Rectangle Area { get; set; }


        public Colision(Rectangle area)
        {
            this.Area = area;
            this._areasParcialesColision = null;
            this._vectorColision = default(Vector2);
        }

        public void CalcularDireccionColision(Rectangle areaColisionable)
        {
            //Obtener los rectángulos parciales
            if (this._areasParcialesColision == null) calcularAreasParciales();

            //Obtenemos en qué areas parciales hay colision
            calcularColisionesParciales(areaColisionable);

            //Obtenemos el vector de colisión en función de en qué áreas hay colisión
            calcularVectorColision();
        }

        /// <summary>
        /// Obtiene las áreas parciales en función del área principal
        /// </summary>
        private void calcularAreasParciales()
        {
            this._areasParcialesColision = new List<AreaParcialColision>();

            int ancho = this.Area.Width / 3;
            int anchoSobrante = this.Area.Width % 3;
            int anchoAcumulado = 0;

            int alto = this.Area.Height / 3;
            int altoSobrante = this.Area.Height % 3;
            int altoAcumulado = 0;

            for (int ejeY = 0; ejeY < 3; ejeY++)
            {
                int altoArea = alto + (altoSobrante * (ejeY % 2));

                anchoAcumulado = 0;
                for (int ejeX = 0; ejeX < 3; ejeX++)
                {
                    if (ejeX != 1 || ejeY != 1)
                    {
                        int anchoArea = ancho + (anchoSobrante * (ejeX % 2));

                        var areaParcial = new Rectangle(this.Area.Left + anchoAcumulado, this.Area.Top + altoAcumulado, anchoArea, altoArea);
                        _areasParcialesColision.Add(new AreaParcialColision(areaParcial, _areasParcialesColision.Count));

                        anchoAcumulado += anchoArea;
                    }
                }

                altoAcumulado += altoArea;
            }
        }

        /// <summary>
        /// Calcula la colisión para cada 
        /// </summary>
        /// <param name="areaColisionable"></param>
        private void calcularColisionesParciales(Rectangle areaColisionable)
        {
            foreach (var areaParcial in _areasParcialesColision)
            {
                areaParcial.Colisiona(areaColisionable);
            }
        }

        /// <summary>
        /// Calcula de dónde viene la colisión en base a los booleanos de las áreas parciales.
        /// </summary>
        /// <returns></returns>
        private void calcularVectorColision()
        {
            Vector2 resultado = new Vector2(0, 0);

            foreach (var areaParcial in this._areasParcialesColision)
            {
                if (areaParcial.HayColision) 
                {
                    resultado += new Vector2((int)areaParcial.ColisionHorizontal, (int)areaParcial.ColisionVertical);
                }
            }

            _vectorColision = resultado;
        }
    }

    /// <summary>
    /// Clase que representa un área parcial de colisión, dentro del objeto colisión.
    /// </summary>
    public class AreaParcialColision
    {
        public AreaParcialColision(Rectangle area, int numero)
        {
            this.Numero = numero;
            this.Area = area;
            this.HayColision = false;

            InitColisionHorizontal();
            InitColisionVertical();
        }

        /// <summary>
        /// Número de área parcial dentro del objeto.
        /// En función del número que sea, la colisión detectada viene de un lado un otro.
        /// -------------
        /// | 0 | 1 | 2 |
        /// | 3 | X | 4 |
        /// | 5 | 6 | 7 |
        /// -------------
        /// </summary>
        public int Numero { get; set; }

        /// <summary>
        /// Rectángulo del área de colisión
        /// </summary>
        public Rectangle Area { get; set; }

        /// <summary>
        /// Indica si en éste área hay colisión o no
        /// </summary>
        public bool HayColision { get; set; }

        /// <summary>
        /// Indica, en caso de haber colisión, de dónde viene en el eje horizontal
        /// </summary>
        public SentidoHorizontal ColisionHorizontal { get; set; }

        /// <summary>
        /// Indica, en caso de haber colisión, de dónde viene en el eje vertical
        /// </summary>
        public SentidoVertical ColisionVertical { get; set; }

        /// <summary>
        /// Calcula el sentido de la colisión horizontal en función del número de área
        /// </summary>
        /// <param name="Numero"></param>
        private void InitColisionHorizontal()
        {
            if (Numero == 0 || Numero == 3 || Numero == 5)
            {
                this.ColisionHorizontal = SentidoHorizontal.Izquierda;
            }
            else if (Numero == 2 || Numero == 4 || Numero == 7)
            {
                this.ColisionHorizontal = SentidoHorizontal.Derecha;
            }
            else
            {
                this.ColisionHorizontal = SentidoHorizontal.Ninguno;
            }
        }

        /// <summary>
        /// Calcula el sentido de la colisión vertical en función del número de área
        /// </summary>
        private void InitColisionVertical()
        {
            if (Numero == 0 || Numero == 1 || Numero == 2)
            {
                this.ColisionVertical = SentidoVertical.Arriba;
            }
            else if (Numero == 5 || Numero == 6 || Numero == 7)
            {
                this.ColisionVertical = SentidoVertical.Abajo;
            }
            else
            {
                this.ColisionVertical = SentidoVertical.Ninguno;
            }
        }

        /// <summary>
        /// Comprueba si éste área colisiona con la pasada por parámetro
        /// </summary>
        /// <param name="areaColisionable">área con la que se quiere comprobar si hay colisión</param>
        internal void Colisiona(Rectangle areaColisionable)
        {
            this.HayColision = this.Area.Intersects(areaColisionable);
        }
    }
}
