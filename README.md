# ASP_NET_MVC 

## How to set up a website using asp.net and enitity framework!

#### Steps
  - 1. Download Visual Studio 2017+
  - 2. Install Asp.net
  - 3. If you have issues with the installation it might be due to the fact that your NuGet settings are Offline.
    - ![Package Manager Settings](https://user-images.githubusercontent.com/46537188/120048701-a789ed80-bfcc-11eb-872a-134fad721585.png)
    - in that case add this source and it should work fine
  - Next to use this there are 3 main components needed to work with.
  - ![Solutions Explorer](https://user-images.githubusercontent.com/46537188/120048727-b7093680-bfcc-11eb-9e45-f3c824ca7e22.png)
    - M: Model
    - V: View
    - C: Controller
    - ![MVC view](https://user-images.githubusercontent.com/46537188/120048743-c1c3cb80-bfcc-11eb-9cd3-0d99f944169c.png)
    - Basically to get them to interact we need to establish an understanding and the above image shows the basic principle of how the data will flow from           start to finish.

In most cases I think starting with the model will be the most simple due to it being kinda of a core to the program you want to build. I.e. lets build a website to show jokes. I can then make a model that would contain properties about what I want for the site.

![jokeclass](https://user-images.githubusercontent.com/46537188/120048911-52021080-bfcd-11eb-9062-a483a2d5c8b6.png)

so my id would be later linked to a db that would have the id of the joke stored, the joke and the answer along with the user who posted it.

After making the class you can then make a controller to manage the data. ---> I would recommend using the automatic generation features to make all the code for you other wise self coding can take a bit and be annoying.

After generating the code you should have a Controller like this.
```
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JokesWebApp_MVC.Data;
using JokesWebApp_MVC.Models;
using Microsoft.AspNetCore.Authorization;

namespace JokesWebApp_MVC.Controllers
{
    public class JokesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public JokesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Jokes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Joke.ToListAsync());
        }

        // POST: Jokes/ShowSearchResults
        public async Task<IActionResult> ShowSearchForm()
        {
            return View();
        }

        public async Task<IActionResult> ShowSearchResults(String SearchPhrase)
        {
            return View("Index",await _context.Joke.Where(j => j.JokeQuestion.Contains(SearchPhrase)).ToListAsync());
        }


        // GET: Jokes/Details/5
        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var joke = await _context.Joke
                .FirstOrDefaultAsync(m => m.Id == id);
            if (joke == null)
            {
                return NotFound();
            }

            return View(joke);
        }

        // GET: Jokes/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Jokes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,JokeQuestion,JokeAnswer,User")] Joke joke)
        {
            if (ModelState.IsValid)
            {
                _context.Add(joke);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(joke);
        }

        // GET: Jokes/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var joke = await _context.Joke.FindAsync(id);
            if (joke == null)
            {
                return NotFound();
            }
            return View(joke);
        }

        // POST: Jokes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,JokeQuestion,JokeAnswer,User")] Joke joke)
        {
            if (id != joke.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(joke);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JokeExists(joke.Id))
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
            return View(joke);
        }

        // GET: Jokes/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var joke = await _context.Joke
                .FirstOrDefaultAsync(m => m.Id == id);
            if (joke == null)
            {
                return NotFound();
            }

            return View(joke);
        }

        // POST: Jokes/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var joke = await _context.Joke.FindAsync(id);
            _context.Joke.Remove(joke);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JokeExists(int id)
        {
            return _context.Joke.Any(e => e.Id == id);
        }
    }
}
```

This will generate along side the Views which should create a Create, Delete, Details, Edit, and Index view and all should be linked up more or less.

Now if you run the page it should look somthing along the lines of this. I added some images so dont worry.
![testwebpage](https://user-images.githubusercontent.com/46537188/120049298-61ce2480-bfce-11eb-9083-7408e4af592b.png)





