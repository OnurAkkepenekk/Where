using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Concrete
{
    public class Score : IEntity
    {
        public int Id { get; set; }
        public int PlaceId { get; set; }
        public double ServiceScore { get; set; }
        public double CovidScore { get; set; }
    }
}
