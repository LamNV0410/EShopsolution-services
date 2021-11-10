using GraphQL.Types;

namespace OrderService.API.GraphQLCore.GraphQLInput
{
    public class OrderInputType : InputObjectGraphType
    {
        public OrderInputType()
        {
            Name = "orderInput";
            Field<NonNullGraphType<StringGraphType>>("name");
            Field<NonNullGraphType<IntGraphType>>("isActive");
            Field<NonNullGraphType<ListGraphType<GuidGraphType>>>("productIds");
            // Field<NonNullGraphType<ListGraphType<IntGraphType>>>("productIds");
        }
    }
}
