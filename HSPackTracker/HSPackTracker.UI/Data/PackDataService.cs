using HSPackTracker.Model;
using System.Collections.Generic;

namespace HSPackTracker.UI.Data
{
    public class PackDataService : IPackDataService
    {
        public IEnumerable<Pack> GetAll()
        {
            // TODO: Load data from real database
            yield return new Pack { SetName = "Classic", EpicCount = 5, EpicPercentage = 50, LegendaryCount = 23, LegendaryPercentage = 45 };
            yield return new Pack { SetName = "Journey to Un'Goro", EpicCount = 8, EpicPercentage = 25, LegendaryCount = 50, LegendaryPercentage = 50 };
            yield return new Pack { SetName = "Knights of the Frozen Throne", EpicCount = 7, EpicPercentage = 30, LegendaryCount = 39, LegendaryPercentage = 100 };
            yield return new Pack { SetName = "Kobolds & Catacombs", EpicCount = 1, EpicPercentage = 5, LegendaryCount = 10, LegendaryPercentage = 20 };
            yield return new Pack { SetName = "The Wichtwood", EpicCount = 9, EpicPercentage = 75, LegendaryCount = 35, LegendaryPercentage = 80 };
        }
    }
}
