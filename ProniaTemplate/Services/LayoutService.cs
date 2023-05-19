using Microsoft.EntityFrameworkCore;
using ProniaTemplate.DAL;
using System;

namespace ProniaTemplate.Services
{
    public class LayoutService
    {
       
            private readonly ProniaDbContext _context;

            public LayoutService(ProniaDbContext context)
            {
                _context = context;
            }
            public async Task<Dictionary<string, string>> GetSettingsAsync()
            {
            Dictionary<string, string> settings = await _context.Settings.ToDictionaryAsync(s => s.Key, s => s.Value);

            return settings;
        }
        
    }
}
