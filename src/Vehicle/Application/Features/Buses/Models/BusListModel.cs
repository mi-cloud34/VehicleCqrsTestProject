
using Application.Features.Buses.Dtos;
using Core.Persistance.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Buses.Models
{
    public class BusListModel : BasePageableModel
    {
        public IList<BusListDto> Items { get; set; }

        //
    }
}
