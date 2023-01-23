using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Cars.Dtos
{
    public class UpdateCarDto
    {
        public int Id { get; set; }
        public int Wheel { get; set; }
        public bool HeadLight { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public int Model { get; set; }
    }
}
