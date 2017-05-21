using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.Semantics;
using Microsoft.EntityFrameworkCore;
using PiCoreSQLite.Models;

namespace PiCoreSQLite.Controllers
{
    public class TasksController : Controller
    {
        private readonly TasksContext Data;

        public TasksController(TasksContext context)
        {
            Data = context;    
        }

        // GET: Tasks
        public async Task<IActionResult> Index()
        {
            var full = new Tuple<IEnumerable<Tasks>, IEnumerable<AssignedTasks>, IEnumerable<CompletedTasks>, Tasks>
            (
                await Data.Tasks.ToListAsync(),
                await Data.AssignedTasks.ToListAsync(),
                await Data.CompletedTasks.ToListAsync(),
                await Data.Tasks.FirstOrDefaultAsync()
            );


            return View(full);
        }

        // GET: Tasks/AddTasks
        public IActionResult AddTasks()
        {
            
            return View();
        }

        // POST: Tasks/AddTasks
        [HttpPost]
        public async Task<IActionResult> AddTasks(TaskAndTime tasks)
        {
            if (ModelState.IsValid)
            {
                Data.Add(tasks.Task);
                await Data.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(tasks);
        }

        // GET: Tasks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tasks = await Data.Tasks
                .SingleOrDefaultAsync(m => m.Id == id);
            if (tasks == null)
            {
                return NotFound();
            }

            return View(tasks);
        }

        // GET: Tasks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tasks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,CreationDate,Difficulty,Duration,Categories")] Tasks tasks)
        {
            if (ModelState.IsValid)
            {
                Data.Add(tasks);
                //Data.SaveChanges();
                await Data.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(tasks);
        }

        // GET: Tasks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tasks = await Data.Tasks.SingleOrDefaultAsync(m => m.Id == id);
            if (tasks == null)
            {
                return NotFound();
            }
            return View(tasks);
        }

        // POST: Tasks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,CreationDate,Difficulty,Duration,Categories")] Tasks tasks)
        {
            if (id != tasks.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    Data.Update(tasks);
                    await Data.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TasksExists(tasks.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(tasks);
        }

        // GET: Tasks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tasks = await Data.Tasks
                .SingleOrDefaultAsync(m => m.Id == id);
            if (tasks == null)
            {
                return NotFound();
            }

            return View(tasks);
        }

        // POST: Tasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tasks = await Data.Tasks.SingleOrDefaultAsync(m => m.Id == id);
            Data.Tasks.Remove(tasks);
            await Data.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool TasksExists(int id)
        {
            return Data.Tasks.Any(e => e.Id == id);
        }

        public async void WriteTasksSet()
        {
            DateTime koniec = DateTime.Today;
            DateTime dzis = DateTime.Today;
            while (koniec < dzis.AddYears(2))
            {
                Data.AssignedTasks.Add(new AssignedTasks() { Date = koniec });
                Data.CompletedTasks.Add(new CompletedTasks() { Date = koniec });
                koniec = koniec.AddDays(1);
            }
            await Data.SaveChangesAsync();
        }
    }
}
