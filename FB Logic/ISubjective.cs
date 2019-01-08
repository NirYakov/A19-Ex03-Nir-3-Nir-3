using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FB_Logic
{
    public interface ISubjective<T1,T2>
    {
        void RegisterObserver(IObserver<T1, T2> i_NewObserver);
        void UnregisterObserver(IObserver<T1, T2> i_DelObserver);
        void NotifyallObservers(T1 i_Item1 , T2 i_Item2);
    }
}
