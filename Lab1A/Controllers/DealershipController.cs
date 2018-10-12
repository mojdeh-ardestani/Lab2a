using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Lab1A.Models;
using Lab1A.Data;

namespace Lab1A.Controllers
{
    public class DealershipController : Controller
    {
            private readonly CarContext _context;
            private DealershipMgr dealershipMgr = new DealershipMgr();


            // GET: Dealership
            public async Task<IActionResult> Index()
            {


                return View(dealershipMgr.Get());
            }

            // GET: Dealership/Details/5
            public async Task<IActionResult> Details(int id)
            {


                var dealership = dealershipMgr.GetOneDealer(id);
                if (dealership == null)
                {
                    return NotFound();
                }

                return View(dealership);
            }

            // GET: Dealership/Create
            public IActionResult Create()
            {
                return View();
            }

            // POST: Dealership/Create
            // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
            // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Create([Bind("ID,Name,Email,PhoneNumber")] Dealership dealership)
            {


                if (ModelState.IsValid)
                {
                    dealershipMgr.Post(dealership);


                    return RedirectToAction(nameof(Index));
                }
                return View(dealership);
            }

            // GET: Dealership/Edit/5
            public async Task<IActionResult> Edit(int id)
            {


                var dealership = dealershipMgr.GetOneDealer(id);
                if (dealership == null)
                {
                    return NotFound();
                }
                return View(dealership);
            }
            // POST: Dealership/Edit/5
            // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
            // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Email,PhoneNumber")] Dealership dealership)
            {
                if (id != dealership.ID)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        dealershipMgr.Put(dealership, dealership.ID);

                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!DealershipExists(dealership.ID))
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
                return View(dealership);
            }



            // GET: Dealership/Delete/5
            public async Task<IActionResult> Delete(int id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var dealership = dealershipMgr.DeleteOneDealer(id);
                if (dealership == null)
                {
                    return NotFound();
                }

                return View();
            }



            private bool DealershipExists(int id)
            {
                return _context.Dealership.Any(e => e.ID == id);
            }
        }
    }
