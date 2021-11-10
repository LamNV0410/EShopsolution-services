using GraphQL.Types;
using Microsoft.Extensions.DependencyInjection;
using OrderService.API.GraphQLCore.MutationObject;
using System;

namespace OrderService.API.GraphQLCore.OrdersSchema
{
    public class OrderQuerySchema : Schema, ISchema
    {
        public OrderQuerySchema(IServiceProvider provider) : base(provider)
        {
            Query = provider.GetRequiredService<QueriesObject.OrderQuery>();
            Mutation = provider.GetRequiredService<OrderMutation>();
        }
    }
}
