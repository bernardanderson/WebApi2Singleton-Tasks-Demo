using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiSingleton.Controllers
{
    public class ThreadSafeSingleton
    {
        // Followed the Thread-Safe singleton pattern listed on this website:
        // https://dotnetcodr.com/2013/05/09/design-patterns-and-practices-in-net-the-singleton-pattern/#comments 
        private List<int> _ints { get; set; } = new List<int> { 1, 2, 3 }; 

        private ThreadSafeSingleton()
        {
        }

        public static ThreadSafeSingleton Instance
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

        public List<int> RemoveLastInt()
        {
            if (_ints.Count != 0)
            {
                _ints.RemoveAt(_ints.Count - 1);
            }
            return _ints;
        }

        public List<int> AddInts()
        {
            if (_ints.Count != 0) {
                _ints.Add(_ints.LastOrDefault<int>() + 1);
            } else
            {
                _ints.Add(1);
            }

            return _ints;
        } 
    }
}
