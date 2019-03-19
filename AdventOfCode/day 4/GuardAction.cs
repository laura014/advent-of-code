using System;

namespace AdventOfCode.day_4
{
    public class GuardAction
    {
        public DateTime DateTime { get; set; }
        public ActionType ActionType { get; set; }
        public int? Id { get; set; }
        public int Minute => DateTime.Minute;

        public GuardAction(string line)
        {
            var separators = new[] { '[', ']' };
            var lineDetails = line.Split(separators);

            DateTime = DateTime.Parse(lineDetails[1]);

            var actionString = lineDetails[2];
            if (actionString.Contains("#"))
            {
                var idDetails = actionString.Split('#');
                var id = idDetails[1].Split(' ')[0];
                Id = int.Parse(id);
                actionString = idDetails[1].Replace(id, "");
            }

            if (Enum.TryParse(actionString.Replace(" ", ""), true, out ActionType actionType))
            {
                ActionType = actionType;
            }
        }
    }
}