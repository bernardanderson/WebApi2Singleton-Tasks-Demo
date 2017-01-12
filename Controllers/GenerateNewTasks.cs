using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebApiSingleton.Models;

namespace WebApiSingleton.Controllers
{
    public class GenerateNewTasks
    {
        private ThreadSafeSingleton myInstance = ThreadSafeSingleton.Instance;

        public void StartNewTask(string sentUserName)
        {
            CancellationTokenSource currentCancellationTokenSource = new CancellationTokenSource();
            CancellationToken userCancellationToken = currentCancellationTokenSource.Token;

            UserTask currentUserTask = new UserTask()
            {
                userName = sentUserName,
                userCancellationTokenSrc = currentCancellationTokenSource
            };

            myInstance.AddUserTask(currentUserTask);
            Task userTask = Task.Run( () => CountNumbers(currentUserTask), userCancellationToken);
        }

        private void CountNumbers(UserTask sentUserTask)
        {
            while (true)
            {
                int lastInt = myInstance.SendInts().LastOrDefault<int>();

                if (sentUserTask.userName == "double")
                {
                    Thread.Sleep(2500);
                    myInstance.AddUserInts(lastInt + 2);
                } else
                {
                    Thread.Sleep(5000);
                    myInstance.AddUserInts(lastInt + 1);
                }

                if (sentUserTask.userCancellationTokenSrc.Token.IsCancellationRequested)
                {
                    break;
                }
            }
        }

        public void StopThread(string sentUserName)
        {
            UserTask returnedUserTask = myInstance.StopUserTask(sentUserName);

            if (returnedUserTask != null)
            {
                returnedUserTask.userCancellationTokenSrc.Cancel();
                returnedUserTask.userCancellationTokenSrc.Dispose();
            }
        }
    }
}
