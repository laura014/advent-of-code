using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.day_4
{
    public class GuardNaps
    {
        public int Id { get; set; }
        public int TotalNapTime { get; set; }
        public int MaxMinuteCount { get; set; }
        public int MaxMinute { get; set; }
        public List<IEnumerable<int>> NapStartMinutes { get; set; }

        public GuardNaps(int id)
        {
            Id = id;
            TotalNapTime = 0;
            MaxMinuteCount = 0;
            MaxMinute = 0;
            NapStartMinutes = new List<IEnumerable<int>>();
        }
    }
}
