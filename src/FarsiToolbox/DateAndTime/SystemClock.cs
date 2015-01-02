using System;

namespace FarsiToolbox.DateAndTime
{
    /// <summary>
    /// An abstraction for current date and time
    /// </summary>
    public class SystemClock
    {
        /// <summary>
        ///Gets the current DateTime
        /// </summary>
        public virtual DateTime Now
        {
            get
            {
                return DateTime.Now;
            }
        }
    }
}
