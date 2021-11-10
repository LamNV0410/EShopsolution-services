using Microsoft.EntityFrameworkCore;
using System;

namespace EshopSolution.Extensions.CustomAttributes
{
    /// <summary>
    /// 
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class Autocommit : Attribute
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public Autocommit(string context)
        {
            this.Context = context;
        }

        /// <summary>
        /// 
        /// </summary>
        public string Context { get; set; }
    }
}
