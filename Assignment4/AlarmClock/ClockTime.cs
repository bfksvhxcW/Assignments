using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clock {

    class ClockTime {

        private int hour;
        private int minute;
        private int second;

        public int Hour => hour;
        public int Minute => minute;
        public int Second => second;

        public ClockTime(int hour = 0, int minute = 0, int second = 0) {
            this.hour = hour;
            this.minute = minute;
            this.second = second;
        }

        public bool isValid() {
            return hour >0 && minute >= 0 && second >= 0
                && hour < 24 && minute < 60 && second < 60;
        }

        public override bool Equals(object obj) {
            var time = obj as ClockTime;
            return time != null &&
                   Hour == time.Hour &&
                   Minute == time.Minute &&
                   Second == time.Second;
        }

        public override int GetHashCode() {
            var hashCode = 1505761165;
            hashCode = hashCode * -1521134295 + Hour.GetHashCode();
            hashCode = hashCode * -1521134295 + Minute.GetHashCode();
            hashCode = hashCode * -1521134295 + Second.GetHashCode();
            return hashCode;
        }
        public override string ToString() {
            return Hour + ":" + Minute + ":" + Second;
        }
    }
}
