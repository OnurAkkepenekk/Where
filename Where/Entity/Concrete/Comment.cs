using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Concrete
{
    public class Comment :IEntity
    {
        public int Id { get; set; }
        public int PlaceId { get; set; }
        public string CommentText { get; set; }
        public double ServiceScore { get; set; }
        public double CovidScore { get; set; }
    }
}
