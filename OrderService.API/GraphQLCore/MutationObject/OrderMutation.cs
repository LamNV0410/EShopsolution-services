using GraphQL;
using GraphQL.Types;
using OrderService.API.GraphQLCore.GraphQLInput;
using OrderService.API.GraphQLCore.OrderRequests;
using OrderService.Domain.DomainModel;
using OrderService.Domain.IRepositories.IGraphQL;

namespace OrderService.API.GraphQLCore.MutationObject
{
    public class OrderMutation: ObjectGraphType
    {
        public OrderMutation(IOrdersRepository ordersRepository)
        {
            Field<OrderType>(
            "createOrder",
            arguments: new QueryArguments(new QueryArgument<NonNullGraphType<OrderInputType>> { Name = "order" }),
            resolve: context =>
            {
                var orderRequest = context.GetArgument<OrderRequest>("order");
                var order = new Order(orderRequest.Name, orderRequest.IsActive == 0 ? false : true, new System.Guid()); ;
                var orderCreated = ordersRepository.CreateOrder(order);
                ordersRepository.BaseRepository.SaveEntitiesAsync();
                return orderCreated;
            }
        );
        }
    }
}
