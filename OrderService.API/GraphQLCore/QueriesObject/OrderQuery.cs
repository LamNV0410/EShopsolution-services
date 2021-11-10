using GraphQL;
using GraphQL.Types;
using OrderService.Domain.IRepositories.IGraphQL;
using System;

namespace OrderService.API.GraphQLCore.QueriesObject
{
    public class OrderQuery : ObjectGraphType<object>
    {
        private readonly IOrdersRepository _repository;
        public OrderQuery(IOrdersRepository repository)
        {
            _repository = repository;
            Name = "OrderQuery";

            Field<OrderType>(
                "order",
                arguments: new QueryArguments(new QueryArgument<GuidGraphType> { Name = "orderId" }),
                resolve: context => repository
                .GetOrderByIdAsync(context.GetArgument<Guid>("orderId"))
                );

            Field<ListGraphType<OrderType>>(
                "orders",
                resolve: context => repository.GetOrdersAsync()
                );
        }
    }
}
