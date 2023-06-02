using System;
using System.Threading;

namespace clock
{
    /// <summary>
    /// Event publisher: Clock class
    /// </summary> 
    class AlarmClock
    {
        public event Action<AlarmClock> AlarmEvent;

        public event Action<AlarmClock> TickEvent;

        public AlarmClock()
        {
            CurrentTime = new ClockTime();
            //为两个事件设置一个内部的处理函数
            TickEvent += c => Console.WriteLine("Tick!" + CurrentTime);
            AlarmEvent += c => Console.WriteLine("Ding! Ding! Ding!");
        }

        public ClockTime CurrentTime { get; set; }

        public ClockTime AlarmTime { get; set; }

        /// start a clock, and keep it run
        public void Run()
        {
            while (true)
            {
                DateTime now = DateTime.Now;
                CurrentTime = new ClockTime(now.Hour, now.Minute, now.Second);
                TickEvent?.Invoke(this);
                if (AlarmTime != null && AlarmTime.Equals(CurrentTime))
                    AlarmEvent?.Invoke(this);
                Thread.Sleep(1000);
            }
        }
    }
}
