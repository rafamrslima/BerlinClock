using BerlinClock.Classes.Interfaces;
using System;
using System.Linq;

namespace BerlinClock.Classes
{
    public class BerlinClockConverter : IBerlinClockConverter
    {
        private readonly string _timeToConvert;

        public BerlinClockConverter(string timeToConvert)
        {
            Validate(timeToConvert);
            _timeToConvert = timeToConvert;
        }

        public string ConvertTime()
        {
            SplitTime(_timeToConvert, out string hour, out string minutes, out string seconds);

            var topYellowLamp = new TopYellowLamp(seconds);
            var hoursLamp = new HoursLamp(hour);
            var minutesLamp = new MinutesLamp(minutes);

            return $"{topYellowLamp.State}\r\n{hoursLamp.TopRow}\r\n{hoursLamp.LowerRow}" +
                   $"\r\n{minutesLamp.TopRow}\r\n{minutesLamp.LowerRow}";
        }
         
        private void SplitTime(string time, out string hour, out string minutes, out string seconds)
        {
            var splitedTime = ConvertTimeToArray(time);
            hour = splitedTime[0];
            minutes = splitedTime[1];
            seconds = splitedTime[2];
        }
           
        private string[] ConvertTimeToArray(string time) => time.Split(':').Select(x => x).ToArray();

        private void Validate(string time)
        {
            var values = ConvertTimeToArray(time);

            if (values.Length != 3)
                throw new ArgumentException("The given values are in an incorrect format. Expected input example: \"01:02:03\".");

            foreach (var value in values)
            {
                if (value.Length != 2)
                    throw new ArgumentException("Each value should be 2 characters long.");

                if (!short.TryParse(value, out _))
                    throw new ArgumentException("The given values should be valid numbers.");
            }

            short.TryParse(values[0], out short hour);
            if (hour < 0 || hour > 24)
                throw new ArgumentException("The hour should be between 00 and 24.");

            short.TryParse(values[1], out short minutes);
            if (minutes < 0 || minutes > 59)
                throw new ArgumentException("The minutes should be between 00 and 59.");

            short.TryParse(values[2], out short seconds);
            if (seconds < 0 || seconds > 59)
                throw new ArgumentException("The seconds should be between 00 and 59.");
        } 

    }
}


