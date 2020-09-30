using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Restaurant_Ratings_Final_Proj.Models;

using Microsoft.AspNetCore.Identity;

 

namespace Restaurant_Ratings_Final_Proj.Controllers
{
    public class RatingsController : Controller
    {
        private readonly Restaurant_Ratings_DataContext _context;

       

        public RatingsController(Restaurant_Ratings_DataContext context
           
            
            )
        {
          
            _context = context;
        }

        // GET: Ratings
        [Authorize(Roles = "rating_admin, customer")]
        public async Task<IActionResult> Index()
        {
            var restaurant_Ratings_DataContext = _context.Rating.Include(r => r.Customer).Include(r => r.Restaurant);
            return View(await restaurant_Ratings_DataContext.ToListAsync());
        }

        // GET: Ratings/Details/5
        [Authorize(Roles = "rating_admin, customer")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rating = await _context.Rating
                .Include(r => r.Customer)
                .Include(r => r.Restaurant)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rating == null)
            {
                return NotFound();
            }

            return View(rating);
        }

        // GET: Ratings/Create
        [Authorize(Roles = "customer")]
        public IActionResult Create(int Id)
        {
           
            ViewData["RestaurantId"] = new SelectList(_context.Set<Restaurant>(), "Id", "RegistredName", Id);
            return View();
        }

        // POST: Ratings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.

        [Authorize(Roles = "customer")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RestaurantId,RatingValue,Comment")] Rating rating)
        {

            var customer = (from cus in _context.Customer
                            where cus.Email.Equals(User.Identity.Name)
                            select cus).FirstOrDefault();

            var existingRating = (from rate in _context.Rating
                                  where rate.CustomerId == customer.Id && rate.RestaurantId == rating.RestaurantId
                                  select rate
                          
                                  ).ToList();


            if (existingRating.Count > 0) {
                ViewData["RestaurantId"] = new SelectList(_context.Set<Restaurant>(), "Id", "RegistredName", rating.RestaurantId);

                ViewData["Error"] = "Invalid: You have already rated this restaurant";
                return View(rating);
            }

            if (ModelState.IsValid)
            {
                rating.CustomerId = customer.Id;
                _context.Add(rating);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
           
            ViewData["RestaurantId"] = new SelectList(_context.Set<Restaurant>(), "Id", "RegistredName", rating.RestaurantId);
            return View(rating);
        }

        // GET: Ratings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rating = await _context.Rating.FindAsync(id);
            if (rating == null)
            {
                return NotFound();
            }
            ViewData["CustomerId"] = new SelectList(_context.Customer, "Id", "Id", rating.CustomerId);
            ViewData["RestaurantId"] = new SelectList(_context.Set<Restaurant>(), "Id", "RegistredName", rating.RestaurantId);
            return View(rating);
        }

        // POST: Ratings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CustomerId,RestaurantId,RatingValue, Comment")] Rating rating)
        {
            if (id != rating.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rating);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RatingExists(rating.Id))
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
            ViewData["CustomerId"] = new SelectList(_context.Customer, "Id", "Id", rating.CustomerId);
            ViewData["RestaurantId"] = new SelectList(_context.Set<Restaurant>(), "Id", "RegistredName", rating.RestaurantId);
            return View(rating);
        }

        // GET: Ratings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rating = await _context.Rating
                .Include(r => r.Customer)
                .Include(r => r.Restaurant)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rating == null)
            {
                return NotFound();
            }

            return View(rating);
        }

        // POST: Ratings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rating = await _context.Rating.FindAsync(id);
            _context.Rating.Remove(rating);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RatingExists(int id)
        {
            return _context.Rating.Any(e => e.Id == id);
        }
    }
}
