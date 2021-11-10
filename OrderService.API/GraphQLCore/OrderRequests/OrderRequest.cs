using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderService.API.GraphQLCore.OrderRequests
{
    public class OrderRequest
    {
        public string Name { get; set; }
        public byte IsActive { get; set; }
        public List<Guid> ProductIds { get; set; }
    }
}
