using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CheckIT.API.Models;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace CheckIT.API.Data
{
    public class PermissionRepository
    {
        private readonly DataContext _context;
        public PermissionRepository(DataContext context)
        {
            _context = context;
        }

    }
}