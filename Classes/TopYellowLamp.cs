using System;

namespace BerlinClock.Classes
{
    public class TopYellowLamp
    {
        public char State { get; private set; }

        public TopYellowLamp(string seconds)
        {
            State = Convert.ToInt16(seconds[1]) % 2 == 0 ?
                                BerlinClockStates.yellow :
                                BerlinClockStates.turnedOff;
        } 
    }
}
