using EshopSolution.Extensions.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace EshopSolution.Extensions.BaseDbContext
{
    public class BaseDbContext : DbContext
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"</param>
        public BaseDbContext(DbContextOptions options)
            : base(options)
        {
            this.TransactionOption = TransactionOption.None;
            this.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

        }

        /// <summary>
        /// 
        /// </summary>
        public bool IsAutoTransaction
        {
            get
            {
                return this.TransactionOption == TransactionOption.AutoTransaction;
            }
        }
        public TransactionOption TransactionOption { get; set; }
        public IExecutionStrategy Scope { get; set; }
        /// <summary>
        /// 
        /// </summary>
        protected IDbContextTransaction Transaction { get; private set; }

        public async Task SetTransactionOption(TransactionOption transactionOption)
        {
            this.TransactionOption = transactionOption;

            if (this.TransactionOption == TransactionOption.AutoTransaction)
            {
                await this.Begin();
            }
        }

        public async Task Begin()
        {
            if (this.Database.CurrentTransaction == null)
            {
                this.Scope = this.Database.CreateExecutionStrategy();
                this.Transaction = await this.Database.BeginTransactionAsync();
            }
        }

        public async Task Commit()
        {
            if (this.Transaction == null)
            {
                throw new ApplicationException("Transaction null");
            }

            await this.Transaction.CommitAsync();
        }

        public async Task Rollback()
        {
            if (this.Transaction == null)
            {
                throw new ApplicationException("Transaction null");
            }

            await this.Transaction.RollbackAsync();
        }

        public async Task DisposeAutoTransaction(bool isException)
        {
            if (!this.IsAutoTransaction)
            {
                return;
            }

            try
            {
                if (isException)
                {
                    await this.Rollback();
                }
                else
                {
                    await this.Commit();
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }

            await this.DisposeAsync();
        }
    }
}
