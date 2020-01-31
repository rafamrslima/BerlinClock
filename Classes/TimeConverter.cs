using BerlinClock.Classes;
using BerlinClock.Classes.Interfaces;

namespace BerlinClock
{
    public class TimeConverter : ITimeConverter
    { 
        public string ConvertTime(string aTime)
        { 
            IBerlinClockConverter berlinClockConverter = new BerlinClockConverter(aTime); 
            return berlinClockConverter.ConvertTime(); 
        } 
    }
}
