using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Subscribe:IEntity
    {
        public int Id { get; set; }
        public int SupUserId { get; set; }
        public int SubUserId { get; set; }

    }
}
