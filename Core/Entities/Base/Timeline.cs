using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Base
{
    public class Timeline
    {
        public DateTime RowInsertionDatetime { get; set; }
        public DateTime RowUpdationDatetime { get; set; }
        public int RowActionCount { get; set; }
    }
}
