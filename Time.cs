using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson12_User_GC
{
    public class Time
    {
        public int Hours { get; set; }
        public int Minutes { get; set; }
        public int Seconds { get; set; }
        public override string ToString()
        {
            var h = ConvertNum(Hours);
            var m = ConvertNum(Minutes);
            var s = ConvertNum(Seconds);
            return $"{h}:{m}:{s}";
        }

        //перегрузка операторов преобразования (implicit/explicit)
        public static implicit operator Time(int seconds)
            => new Time
            {
                Hours = seconds / 3600,
                Minutes = seconds % 3600 / 60,
                Seconds = seconds % 60
            };
        public static explicit operator int(Time time)
            => time.Hours * 3600 + time.Minutes * 60 + time.Seconds;

       

        private string ConvertNum(int num) => num < 10 ? $"0{num}" : num.ToString();
    }
}
