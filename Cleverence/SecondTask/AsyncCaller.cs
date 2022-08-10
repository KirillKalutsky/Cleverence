using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cleverence.SecondTask
{
    public class AsyncCaller
    {
        private Func<Task> action;

        public AsyncCaller(Func<Task> action)
        {
            this.action = action;
        }
        public async Task<bool> Invoke(int miliSeconds)
        {
            var delegateTask = action.Invoke();
            var border = Task.Delay(miliSeconds);

            await Task.WhenAny(delegateTask,border);

            return delegateTask.IsCompleted;
        }
    }
}
