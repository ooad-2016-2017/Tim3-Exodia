using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class GORepository : Container
    {
        public GameObject[] hotel;

        public GORepository(ref GameObject[] hotel)
        {
            this.hotel = hotel;
        }

        public Iterator getIterator()
        {
            return new GOIterator(ref hotel);
        }
        private class GOIterator : Iterator
        {
            int index;
            public GameObject[] hotel;

            public GOIterator(ref GameObject[] hotel)
            {
                this.hotel = hotel;
            }

            public bool hasNext()
            {
                if (index < hotel.Length)
                {
                    return true;
                }
                return false;
            }
            public object next()
            {
                if (this.hasNext())
                {
                    return hotel[index++];
                }
                return null;
            }
        }
    }
}
