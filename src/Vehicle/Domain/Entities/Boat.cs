
using Core.Persistance.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Boat:Entity
    {
        public Boat()
        {

        }
        public Boat(int id,string name, string color, int model):this()
        {
            Id = id;
            Name = name;
            Color = color;
            Model = model;
        }
    }
}
