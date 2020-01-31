using System;

namespace BerlinClock.Classes
{
    public class MinutesLamp
    {
        private readonly string _minutes;
        public string TopRow { get; private set; }
        public string LowerRow { get; private set; }

        public MinutesLamp(string minutes)
        {
            _minutes = minutes;
            SetTopRow();
            SetLowerRow();
        }

        private void SetTopRow()
        {
            var spacesToFill = Convert.ToInt16(_minutes) / 5;

            var filledLine = string.Empty.PadLeft(spacesToFill, Convert.ToChar(BerlinClockStates.yellow))
                .PadRight(11, BerlinClockStates.turnedOff);

            TopRow = filledLine.Replace(new string(BerlinClockStates.yellow, 3), 
                string.Concat(new string(BerlinClockStates.yellow, 2), BerlinClockStates.red));
        }

        private void SetLowerRow()
        {
            LowerRow = new string(BerlinClockStates.turnedOff, 4);
            var secondChar = Convert.ToInt16(_minutes[1].ToString());

            if (secondChar % 5 != 0)
            {
                if (secondChar > 5)
                    secondChar -= 5;
 
                LowerRow = string.Empty.PadLeft(secondChar, BerlinClockStates.yellow).PadRight(4, BerlinClockStates.turnedOff);
            }
        }
    }
}
