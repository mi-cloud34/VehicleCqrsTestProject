using Application.Features.Buses.Dtos;
using Core.Persistance.Paging;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Boats.Models
{
    public class BoatListModel : BasePageableModel
    {
        public IList<BusListDto> Items { get; set; }

        //
    }
}
