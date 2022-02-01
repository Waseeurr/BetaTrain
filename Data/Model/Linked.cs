using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test_4._0.Data.Model
{
    public class Linked
    {
        public long Id { get; set; }
        public long TraineeId { get; set; }
        public long TrainerId { get; set; }
        public int Status { get; set; }
    }
}
