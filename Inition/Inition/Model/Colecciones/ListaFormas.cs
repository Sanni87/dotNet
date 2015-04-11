using Inition.Model.Interfaces;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Inition.Model.Colecciones
{
    public class ListaFormas : ICollection<IForma>
    {

        private List<IForma> elementos;


        public void Update()
        {
            foreach (IForma forma in this.elementos)
            {
                forma.Update();
            }
        }

        public void Draw(ref SpriteBatch spriteBatch)
        {
            foreach (IForma forma in this.elementos)
            {
                forma.Draw(ref spriteBatch);
            }
        }

        #region ICollection
        public ListaFormas()
        {
            this.elementos = new List<IForma>();
        }

        public void Add(IForma item)
        {
            this.elementos.Add(item);
        }

        public void Clear()
        {
            this.elementos.Clear();
        }

        public bool Contains(IForma item)
        {
            return this.elementos.Contains(item);
        }

        public void CopyTo(IForma[] array, int arrayIndex)
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

        public bool Remove(IForma item)
        {
            return this.elementos.Remove(item);
        }

        public IEnumerator<IForma> GetEnumerator()
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
