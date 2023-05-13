using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class CarOwnerUserDto:IEntity
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserMail { get; set; }
        public string Color { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
    }
}
