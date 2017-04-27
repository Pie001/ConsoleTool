using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTool.Services
{
    public abstract class BaseService
    {
        protected Result Result { get; set; }

        public BaseService() { }

        public abstract void Invoke();
    }
}
