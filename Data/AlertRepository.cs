using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CheckIT.API.Models;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace CheckIT.API.Data
{
    public class AlertRepository
    {
        private readonly DataContext _context;
        public AlertRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Alert> AddAlert(Alert alert)
        {
            //save to database.
            await _context.Alerts.AddAsync(alert);
            await _context.SaveChangesAsync();

            return alert;
        }

        public async Task<Alert> GetAlert(int alertID)
        {
            Alert alert = await _context.Alerts.Include(x => x.AlertInv)
                                               .FirstOrDefaultAsync(x => x.Id == alertID);
            return alert;
        }

        public async Task<List<Alert>> GetAllAlerts()
        {
            List<Alert> alerts = await _context.Alerts.Include(x => x.AlertInv).ToListAsync();
            return alerts;
        }

        public async Task<Alert> DeleteAlert(int alertID)
        {
            var alert = await _context.Alerts.FirstOrDefaultAsync(x => x.Id == alertID);

            if(alert == null)
            {
                return null;
            }
            else
            {
                _context.Alerts.Remove(alert);
            }

            await _context.SaveChangesAsync();

            return alert;
        }

        public async Task<Alert> UpdateAlert(Alert alert)
        {
            //update database
            //await _context.Inventory.AddAsync(inventory);
            _context.Alerts.Update(alert); //Async? even need to use update?
            await _context.SaveChangesAsync();

            return alert;
        }

        public async Task<DateTime?> OrderedMore(int Id)
        {
             Alert alert;
            alert = await GetAlert(Id);

            if (alert.AlertOn == true)
            {
                alert.DateOrdered = DateTime.Now;
                _context.Alerts.Update(alert);
                await _context.SaveChangesAsync();
                return alert.DateOrdered;
            }
            else
            {
                return DateTime.MinValue;
            }
        }
    }
}