
using Core.Persistance.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Car:Entity
    {
        public int Wheel { get; set; }
        public bool HeadLight { get; set; }
        public Car()
        {

        }
        public Car(int id,int wheel,bool headlight, string name, string color, int model):this()
        {
            Id = id;
            Wheel = wheel;
            HeadLight = headlight;
            Name = name;
            Color = color;
            Model = model;

        }
    }
    
}
