using EventEase.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventEase.Services
{
    public class EventService
    {
        private readonly List<EventModel> _events;

        public EventService()
        {
            // seed mock events
            _events = new List<EventModel>
            {
                new EventModel { Id = Guid.NewGuid(), Name = "Annual Tech Summit", Date = DateTime.Today.AddDays(14), Location = "Mumbai" },
                new EventModel { Id = Guid.NewGuid(), Name = "Team Building Retreat", Date = DateTime.Today.AddDays(30), Location = "Goa" },
                new EventModel { Id = Guid.NewGuid(), Name = "Charity Gala", Date = DateTime.Today.AddDays(45), Location = "Delhi" },
            };
        }

        public Task<List<EventModel>> GetEventsAsync() => Task.FromResult(_events.ToList());

        public Task<EventModel?> GetEventByIdAsync(Guid id) => Task.FromResult(_events.FirstOrDefault(e => e.Id == id));

        // persist in-memory update
        public Task<bool> UpdateEventAsync(EventModel updated)
        {
            var idx = _events.FindIndex(e => e.Id == updated.Id);
            if (idx == -1) return Task.FromResult(false);

            _events[idx] = updated;
            return Task.FromResult(true);
        }

        // generate a large list for performance testing
        public Task<List<EventModel>> GenerateLargeEventListAsync(int count = 1000)
        {
            var list = Enumerable.Range(1, count).Select(i => new EventModel
            {
                Id = Guid.NewGuid(),
                Name = $"Event {i}",
                Location = $"City {i % 50}",
                Date = DateTime.Today.AddDays(i)
            }).ToList();

            return Task.FromResult(list);
        }
    }
}
