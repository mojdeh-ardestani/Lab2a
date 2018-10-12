using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Lab1A.Models;

namespace Lab1A.Controllers
{
    public class MemberController : Controller
    {
       
            private readonly CarContext _context;

            public MemberController(CarContext context)
            {
                _context = context;
            }

            // GET: Member
            public async Task<IActionResult> Index()
            {
                return View(await _context.Member.ToListAsync());
            }

            // GET: Member/Details/5
            public async Task<IActionResult> Details(string id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var member = await _context.Member
                    .FirstOrDefaultAsync(m => m.UserName == id);
                if (member == null)
                {
                    return NotFound();
                }

                return View(member);
            }

            // GET: Member/Create
            public IActionResult Create()
            {
                return View();
            }

            // POST: Member/Create
            // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
            // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Create([Bind("FirstName,LastName,UserName,Email,Company,Position,BirthDate")] Member member)
            {
                if (ModelState.IsValid)
                {
                    _context.Add(member);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                return View(member);
            }

            // GET: Member/Edit/5
            public async Task<IActionResult> Edit(string id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var member = await _context.Member.FindAsync(id);
                if (member == null)
                {
                    return NotFound();
                }
                return View(member);
            }

            // POST: Member/Edit/5
            // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
            // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Edit(string id, [Bind("FirstName,LastName,UserName,Email,Company,Position,BirthDate")] Member member)
            {
                if (id != member.UserName)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(member);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!MemberExists(member.UserName))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                    return RedirectToAction(nameof(Index));
                }
                return View(member);
            }

            // GET: Member/Delete/5
            public async Task<IActionResult> Delete(string id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var member = await _context.Member
                    .FirstOrDefaultAsync(m => m.UserName == id);
                if (member == null)
                {
                    return NotFound();
                }

                return View(member);
            }

            // POST: Member/Delete/5
            [HttpPost, ActionName("Delete")]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> DeleteConfirmed(string id)
            {
                var member = await _context.Member.FindAsync(id);
                _context.Member.Remove(member);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }


            public async Task<IActionResult> SeedDB()
            {
                if (_context.Member.Count() == 0)
                {
                    Member member1 = new Member { FirstName = "Jack", LastName = "Smith", UserName = "jack.smith", Email = "Jack.Smith@yahoo.com" };
                    Member member2 = new Member { FirstName = "John", LastName = "Smith", UserName = "John.smith", Email = "John.Smith@yahoo.com" };
                    _context.Member.AddRange(member1, member2);
                    await _context.SaveChangesAsync();
                }

                return RedirectToAction(nameof(Index));
            }


            private bool MemberExists(string id)
            {
                return _context.Member.Any(e => e.UserName == id);
            }
        }
    }
