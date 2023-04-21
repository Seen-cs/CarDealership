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
    }
}
