﻿
using EshopSolution.Extensions.BaseAPI;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SystemService.Domain.DTOs;

namespace SystemService.Domain.IQueries
{
    public interface IUserQueries
    {
        /// <summary>
        ///  Get Users Paging
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="createdDate"></param>
        /// <param name="userId"></param>
        /// <param name="page"></param>
        /// <param name="size"></param>
        /// <param name="sortField"></param>
        /// <param name="sortDirection"></param>
        /// <returns></returns>
        Task<IPaginatorResponse<UsersDTO>> GetUsersPaging(
            string keyword,
            DateTime? createdDate,
            Guid? userId,
            int page,
            int size,
            string sortField,
            string sortDirection,
            bool getCount
            );
        /// <summary>
        /// Get user by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<UsersDTO> GetByIdAsync(Guid id);
    }
}