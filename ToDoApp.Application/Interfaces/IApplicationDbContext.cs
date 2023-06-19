﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ToDoApp.Domain.Entities;

namespace ToDoApp.Application.Interfaces
{
    public interface IApplicationDbContext
    {
        public DbSet<ToDoList> Departments { get; set; }
        public DbSet<ToDoItem> Employees { get; set; }
     
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
