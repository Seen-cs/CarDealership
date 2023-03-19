using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class UserCar:IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int CarId { get; set; }
        public int Stock { get; set; }
    }
}
