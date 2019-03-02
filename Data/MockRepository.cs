using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CheckIT.API.Models;
using CheckIT.API.Dtos;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using CheckIT.API.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace CheckIT.API.Data
{
    public class MockRepository
    {
        private readonly DataContext _context;
        public MockRepository(DataContext context)
        {
            _context = context;
        }
        
        public void FillMockTable()
        {
            DataMocker.InsertMockData(_context);
        }
        public void ClearMockData()
        {
            DataMocker.RemoveMockData(_context);
        }
    }
}