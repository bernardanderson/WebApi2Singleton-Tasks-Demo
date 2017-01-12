using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiSingleton.Models;

namespace WebApiSingleton.Controllers
{
    public class ThreadSafeSingleton
    {
        private List<UserTask> _userTask { get; set; } = new List<UserTask>();
        private List<int> _counterInts { get; set; } = new List<int>();

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

        public void AddUserTask(UserTask sentUserTask)
        {
            _userTask.Add(sentUserTask);
        }

        public UserTask StopUserTask(string sentUserName)
        {
            UserTask foundUserTask = _userTask.FirstOrDefault(un => un.userName == sentUserName);

            if (foundUserTask != null)
            {
                _userTask.Remove(foundUserTask);
            }

            return foundUserTask;
        }

        public void AddUserInts(int sentInt)
        {
            _counterInts.Add(sentInt);
        }

        public List<int> SendInts()
        {
            return _counterInts;
        }

        public int RetrieveUserTask()
        {
            return _userTask.Count;
        }
    }
}
