using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Location : IEntity 
    {
        public int Id { get; set; }
        public int PlaceId { get; set; }
        public int Coord { get; set; }
    }
}
