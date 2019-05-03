using System;
using Microsoft.AspNetCore.Mvc;

namespace PalTracker
{
    [Route("/time-entries")]
    public class TimeEntryController : ControllerBase
    {
        private readonly ITimeEntryRepository _timeEntryRepository;
        public TimeEntryController(ITimeEntryRepository timeEntryRepository)
        {
            _timeEntryRepository=timeEntryRepository;
        }
        [HttpGet("{id}", Name="GetTimeEntry")]
        public IActionResult Read(long id)
        {
             return _timeEntryRepository.Contains(id) ? (IActionResult) Ok(_timeEntryRepository.Find(id)) : NotFound();
        }

        [HttpPost]
        public IActionResult Create([FromBody] TimeEntry toCreate)
        {
           TimeEntry newEntry=_timeEntryRepository.Create(toCreate);
           return CreatedAtRoute("GetTimeEntry", new {id = newEntry.Id}, newEntry);
        }

        [HttpGet]
        public IActionResult List()
        {
           return Ok(_timeEntryRepository.List());
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] TimeEntry toUpdate)
        {
            return _timeEntryRepository.Contains(id) ? (IActionResult) Ok(_timeEntryRepository.Update(id,toUpdate)):NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
           if(! _timeEntryRepository.Contains(id))
           {
               return NotFound();
           }
           _timeEntryRepository.Delete(id);
           return NoContent();
        }
    }
}