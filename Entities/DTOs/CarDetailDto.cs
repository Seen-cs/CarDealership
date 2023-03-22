using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class CarDetailDto:IEntity
    {
        public int CarId { get; set; }
        public string color { get; set; }
        public string brand { get; set; }
        public string model { get; set; }
        public string userName { get; set; }
        public string km { get; set; }
        public int price { get; set; }
        public string year { get; set; }
        public string description { get; set; }





    }
}
