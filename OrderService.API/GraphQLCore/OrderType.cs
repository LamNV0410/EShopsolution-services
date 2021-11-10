using GraphQL.Types;
using OrderService.Domain.DomainModel;
using OrderService.Domain.IRepositories.IGraphQL;

namespace OrderService.API.GraphQLCore
{
    public class OrderType : ObjectGraphType<Order>
    {
        public OrderType(IOrdersRepository repository)
        {
            Field(x => x.Id).Description(" Order Id ");
            Field(x => x.Name).Description(" Order Name ");
            Field(x => x.IsActive).Description(" Active Order ");

            Field<ListGraphType<OrderDetailType>>(
               "orderDetails",
               arguments: new QueryArguments(new QueryArgument<GuidGraphType> { Name = "orderId" }),
               resolve: context => repository.GetOrderDetailByOrderId(context.Source.Id)
               );
        }
    }
}
