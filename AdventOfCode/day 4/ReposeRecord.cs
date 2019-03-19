using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.day_4
{
    public static class ReposeRecord
    {
        public static int GetMostSleepyGuard(string[] inputLines)
        {
            var naps = new List<GuardNaps>();
            var guardActions = inputLines.Select(line => new GuardAction(line))
                .OrderBy(line => line.DateTime).ToList();

            var currentId = 0;
            for (var i = 0; i < guardActions.Count - 1; i++)
            {
                var guardShift = guardActions[i];
                if (guardShift.Id.HasValue)
                {
                    currentId = guardShift.Id.Value;
                }

                if (currentId == 0)
                {
                    continue;
                }

                var guardBreak = new GuardNaps(currentId);

                if (guardShift.ActionType == ActionType.FallsAsleep && guardActions[i + 1].ActionType == ActionType.WakesUp)
                {
                    var currentNap = guardActions[i + 1].Minute - guardShift.Minute;
                    guardBreak.TotalNapTime += currentNap;
                    guardBreak.NapStartMinutes.Add(Enumerable.Range(guardShift.Minute, currentNap));
                }

                var indexOfGuard = naps.FindIndex(n => n.Id == guardBreak.Id);
                if (indexOfGuard != -1)
                {
                    naps[indexOfGuard].NapStartMinutes.AddRange(guardBreak.NapStartMinutes);
                    naps[indexOfGuard].TotalNapTime += guardBreak.TotalNapTime;
                }
                else
                {
                    naps.Add(guardBreak);
                }
            }

            var maxNap = naps.OrderByDescending(n => n.TotalNapTime).First();

            var maxMinutes = maxNap.NapStartMinutes
                .SelectMany(m => m)
                .GroupBy(min => min)
                .Where(min => min.Count() > 1)
                .Select(m => new { m.Key, Count = m.Count() }).ToList();
            var minute = maxMinutes.OrderByDescending(x => x.Count).Select(x => x.Key).First();

            return maxNap.Id * minute;
        }

        public static int GetMostNapyGuard(string[] inputLines)
        {
            var naps = new List<GuardNaps>();
            var guardActions = inputLines.Select(line => new GuardAction(line))
                .OrderBy(line => line.DateTime).ToList();

            var currentId = 0;
            for (var i = 0; i < guardActions.Count - 1; i++)
            {
                var guardShift = guardActions[i];
                if (guardShift.Id.HasValue)
                {
                    currentId = guardShift.Id.Value;
                }

                if (currentId == 0)
                {
                    continue;
                }

                var guardBreak = new GuardNaps(currentId);
                var indexOfGuard = naps.FindIndex(n => n.Id == guardBreak.Id);

                if (guardShift.ActionType == ActionType.FallsAsleep && guardActions[i + 1].ActionType == ActionType.WakesUp)
                {
                    var currentNap = guardActions[i + 1].Minute - guardShift.Minute;
                    guardBreak.TotalNapTime += currentNap;
                    guardBreak.NapStartMinutes.Add(Enumerable.Range(guardShift.Minute, currentNap));
                    if (indexOfGuard != -1)
                    {
                        naps[indexOfGuard].NapStartMinutes.AddRange(guardBreak.NapStartMinutes);
                        naps[indexOfGuard].TotalNapTime += guardBreak.TotalNapTime;
                    }
                    else
                    {
                        naps.Add(guardBreak);
                    }
                }

                if (indexOfGuard != -1 && (guardActions[i + 1].ActionType == ActionType.BeginsShift || i + 1 == guardActions.Count - 1))
                {
                    var maxMinute = naps[indexOfGuard].NapStartMinutes
                           .SelectMany(m => m)
                           .GroupBy(min => min)
                           .Where(min => min.Count() > 1)
                           .Select(m => new { m.Key, Count = m.Count() })
                           .OrderByDescending(x => x.Count)
                           .FirstOrDefault();
                    if (maxMinute != null)
                    {
                        naps[indexOfGuard].MaxMinute = maxMinute.Key;
                        naps[indexOfGuard].MaxMinuteCount = maxMinute.Count;
                    }
                }
            }

            var maxNap = naps.OrderByDescending(n => n.MaxMinuteCount).First();

            return maxNap.Id * maxNap.MaxMinute;
        }

        private static List<GuardNaps> GetGuardsNaps(string[] inputLines)
        {
            var naps = new List<GuardNaps>();
            var guardActions = inputLines.Select(line => new GuardAction(line))
                .OrderBy(line => line.DateTime).ToList();

            var currentId = 0;
            for (var i = 0; i < guardActions.Count - 1; i++)
            {
                var guardShift = guardActions[i];
                if (guardShift.Id.HasValue)
                {
                    currentId = guardShift.Id.Value;
                }

                if (currentId == 0)
                {
                    continue;
                }

                var guardBreak = new GuardNaps(currentId);

                if (guardShift.ActionType == ActionType.FallsAsleep && guardActions[i + 1].ActionType == ActionType.WakesUp)
                {
                    var currentNap = guardActions[i + 1].Minute - guardShift.Minute;
                    guardBreak.TotalNapTime += currentNap;
                    guardBreak.NapStartMinutes.Add(Enumerable.Range(guardShift.Minute, currentNap));
                }

                var indexOfGuard = naps.FindIndex(n => n.Id == guardBreak.Id);
                if (indexOfGuard != -1)
                {
                    naps[indexOfGuard].NapStartMinutes.AddRange(guardBreak.NapStartMinutes);
                    naps[indexOfGuard].TotalNapTime += guardBreak.TotalNapTime;
                }
                else
                {
                    naps.Add(guardBreak);
                }
            }

            return naps;
        }
    }
}
