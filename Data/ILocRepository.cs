using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CheckIT.API.Models;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace CheckIT.API.Data
{
    public interface ILocRepository
    {
        Task<Location> AddLocation(Location loc);
        Task<Location> GetLocation(int locID);
        Task<List<Location>> GetAllLocations();
        Task<Location> DeleteLocation(int locID);
    }
}