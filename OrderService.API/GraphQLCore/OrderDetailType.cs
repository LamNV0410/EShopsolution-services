using GraphQL.Types;
using OrderService.Domain.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderService.API.GraphQLCore
{
    public class OrderDetailType : ObjectGraphType<OrderDetail>
    {
        public OrderDetailType()
        {
            Field(x => x.Id).Description(" OrderDetail Id ");
            Field(x => x.ProductId).Description(" Product Id ");
            Field(x => x.OrderId).Description(" Order Id ");
        }
    }
}
