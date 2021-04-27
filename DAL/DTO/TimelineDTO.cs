using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.DTO
{
    public class TimelineDTO
    {
        public DateTime RowInsertionDatetime { get; set; }
        public DateTime RowUpdationDatetime { get; set; }
        public int RowActionCount { get; set; }
    }
}
