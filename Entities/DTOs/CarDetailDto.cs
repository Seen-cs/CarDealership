using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class CarDetailDto:IEntity
    {
        public int CarId { get; set; }
        public string UserName { get; set; }
        public string Color { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Km { get; set; }
        public int Price { get; set; }
        public string Year { get; set; }
        public string Description { get; set; }





    }
}
