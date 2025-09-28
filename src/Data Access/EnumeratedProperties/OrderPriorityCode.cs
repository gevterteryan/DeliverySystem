using System;

namespace Data_Access.EnumeratedProperties
{
    public class OrderPriorityCode
    {
        public enum Status
        {
            Accepted,
            Assigned,
            Arrived,
            Departed,
            Completed
        }
    }
}
