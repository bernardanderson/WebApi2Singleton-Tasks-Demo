using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiSingleton.Controllers
{
    public class ThreadSafeSingleton
    {
        private List<int> _ints;

        private ThreadSafeSingleton()
        {
        }

        private static ThreadSafeSingleton Instance
        {
            get { return Nested.instance; }
        }

        private class Nested
        {
            static Nested()
            {
            }

            internal static readonly ThreadSafeSingleton instance = new ThreadSafeSingleton();
        }

        public void AddInts (int sentInts)
        {
            _ints.Add(sentInts);
        } 

        public List<int> ReturnInts()
        {
            return _ints;
        }


    }
}
