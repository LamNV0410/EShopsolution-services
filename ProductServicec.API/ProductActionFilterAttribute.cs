using EshopSolution.Extensions.CustomAttributes;
using EshopSolution.Extensions.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using ProductService.Infrastructure.DBContext;
using ProductService.Infrastructure.Repositoies;
using System.Reflection;

namespace ProductService.API
{
    public class ProductActionFilterAttribute : ActionFilterAttribute
    {
        public TransactionOption TransactionOption { get; set; }
        private IScopeClass Context { get; set; }
        private Autocommit Autocommit { get; set; }
        public ProductActionFilterAttribute(IScopeClass context)
        {
            this.Context = context;

        }

        public override void OnActionExecuting(ActionExecutingContext actionContext)
        {
            ControllerActionDescriptor actionDescriptor =
                actionContext.ActionDescriptor as ControllerActionDescriptor;
            Controller controller = actionContext.Controller as Controller;
            if (controller != null)
            {
                if (actionDescriptor != null
                && actionDescriptor.MethodInfo.GetCustomAttribute<Autocommit>() != null)
                {
                    this.Autocommit = actionDescriptor.MethodInfo.GetCustomAttribute<Autocommit>();

                    try
                    {
                        this.BeginAutoTransaction();
                    }
                    catch (System.Exception)
                    {
                        this.DisposeAutoTransaction(true);
                        throw;
                    }
                }
            }
        }

        public override void OnActionExecuted(ActionExecutedContext actionContext)
        {
            this.DisposeAutoTransaction(actionContext.Exception != null);
        }

            private void BeginAutoTransaction()
        {
            if (this.Autocommit == null)
            {
                return;
            }
            else
            {
                this.Context.Context.SetTransactionOption(TransactionOption.AutoTransaction);
            }


        }

        private void DisposeAutoTransaction(bool isException)
        {
            if (this.Autocommit == null)
            {
                return;
            }
            else
            {
                this.Context.Context.DisposeAutoTransaction(isException);
            }

        }
    }
}
