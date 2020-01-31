using System;

namespace BerlinClock.Classes
{
    public class HoursLamp
    {
        private readonly string _hour;
        public string TopRow { get; private set; }
        public string LowerRow { get; private set; }

        public HoursLamp(string hour)
        {
            _hour = hour;
            SetTopRow();
            SetLowerRow();
        }

        private void SetTopRow()
        {
            var spacesToFill = Convert.ToInt16(_hour) / 5;
            TopRow = string.Empty.PadLeft(spacesToFill, BerlinClockStates.red).PadRight(4, BerlinClockStates.turnedOff);
        }

        private void SetLowerRow()
        {
            LowerRow = new string(BerlinClockStates.turnedOff, 4);
            var secondChar = Convert.ToInt16(_hour[1].ToString());

            if (secondChar % 5 != 0)
            {
                if (secondChar > 5)
                    secondChar -= 5;

                LowerRow = string.Empty.PadLeft(secondChar, BerlinClockStates.red).PadRight(4, BerlinClockStates.turnedOff);
            } 
        }
    }
}
