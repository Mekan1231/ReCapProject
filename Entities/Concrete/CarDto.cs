using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class CarDto:IEntities
    {
        public int CarId { get; set; }
        public string CarName { get; set; }
        public int DailyPrice { get; set; }
    }
}
