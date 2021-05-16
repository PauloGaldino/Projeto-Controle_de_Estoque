using Domain.Core.Events;
using Infra.Data.Contexts;
using Infra.Data.Repositories.Evnetsouercings.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infra.Data.Repositories.Evnetsouercings
{
    public class EventStoreSQLRepository : IEventStoreRepository
    {
        private readonly EventStoreSqlContext _context;

        public EventStoreSQLRepository(EventStoreSqlContext context)
        {
            _context = context;
        }

        public async Task<IList<StoredEvent>> All(Guid aggregateId)
        {
            return await (from e in _context.StoredEvent where e.aggregateId == aggregateId select e).ToListAsync();
        }

        public void Store(StoredEvent theEvent)
        {
            _context.Add(theEvent);
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
