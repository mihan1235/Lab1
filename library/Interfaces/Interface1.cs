using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library
{
    public interface IDeepCopy
    {
        object DeepCopy();
    }

    public interface ITeamCount
    {
        int Count
        {
            get;
        }
    }

    public interface IAverageTimeFrame
    {
        double AverageTimeFrame
        {
            get;
        }
        int CompareTo(IAverageTimeFrame obj);
    }
}
