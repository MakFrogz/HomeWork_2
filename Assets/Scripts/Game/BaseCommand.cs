using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zenject;

namespace Assets.Scripts.Infrastructure
{
    public abstract class BaseCommand<T>
    {
        public class Factory : PlaceholderFactory<T>
        {

        }

        public abstract void Execute();
    }
}
