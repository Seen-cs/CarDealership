using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class SubscribeDetailDto:IEntity
    {
        public int Id { get; set; }
        public string SupUser { get; set; }
        public string SubUser { get; set; }
    }
}
