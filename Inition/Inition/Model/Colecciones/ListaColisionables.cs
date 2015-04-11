using Inition.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Inition.Model.Colecciones
{
    public class ListaColisionables : ICollection<IColisionable>
    {
        private List<IColisionable> elementos;

        public ListaColisionables()
        {
            this.elementos = new List<IColisionable>();
        }

        /// <summary>
        /// Función que comprueba las colisiones de todos los elementos una vez actualizados y llama a sus funciones para reaccionar ante la colision
        /// </summary>
        public void ComprobarColisiones()
        {
            var copiaLista = new List<IColisionable>(this.elementos);

            foreach (var colisionableA in this.elementos)
            {
                foreach (var colisionableB in copiaLista)
                {
                    if (colisionableA != colisionableB)
                    {
                        //Para cada par de elementos, comnprobamos si hay colisiones
                        if (colisionableA.Colisiona(colisionableB))
                        {
                            //Comprobamos los cálculos a realizar 
                            colisionableA.ComprobarColision(colisionableB);
                            colisionableB.ComprobarColision(colisionableA);

                            colisionableA.ReaccionarAColision(colisionableB);
                            colisionableB.ReaccionarAColision(colisionableA);
                        }
                    }
                }
                copiaLista.Remove(colisionableA);
            }
        }

        #region ICollection
        public void Add(IColisionable item)
        {
            this.elementos.Add(item);
        }

        public void Clear()
        {
            this.elementos.Clear();
        }

        public bool Contains(IColisionable item)
        {
            return this.elementos.Contains(item);
        }

        public void CopyTo(IColisionable[] array, int arrayIndex)
        {
            this.elementos.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get { return this.elementos.Count; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public bool Remove(IColisionable item)
        {
            return this.elementos.Remove(item) ;
        }

        public IEnumerator<IColisionable> GetEnumerator()
        {
           return this.elementos.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.elementos.GetEnumerator();
        }
        #endregion
    }
}
