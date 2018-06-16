using System.Collections.Generic;
using HSPackTracker.Model;

namespace HSPackTracker.UI.Data
{
    public interface IPackDataService
    {
        IEnumerable<Pack> GetAll();
    }
}