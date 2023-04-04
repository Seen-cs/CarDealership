using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class CarDetailDto:IEntity
    {
        public int CarId { get; set; }
        public int ColorId { get; set; }
        public int BrandId { get; set; }
        public int ModelId { get; set; }
        public string Km { get; set; }
        public int Price { get; set; }
        public string Year { get; set; }
        public string Description { get; set; }





    }
}
