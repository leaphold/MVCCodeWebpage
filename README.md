[![Review Assignment Due Date](https://classroom.github.com/assets/deadline-readme-button-24ddc0f5d75046c5622901739e7c5dd533143b0c8e959d652212380cedb1ea36.svg)](https://classroom.github.com/a/yQVrbHPz)


Jag stötte inte på några större utmaningar denn gången utan allt flöt på rätt så bra.
Det som jag stött på vidare i kursen är just det problemet som kan uppstå när man ska redigera någonting vi en Edit model. Så istället för att uppdatera så lägger den till en ny kyrs.
Detta stötte jag på senare i RazorPages och har inte lyckats lösa ännu.

Även provat med att lägga till en <input asp-for="Category" hidden/> Postar min Edit längst ned i dokumentet.
Det är något jag fortsätter med att försöka lösa. Har provat kopiera precis vad Udemy kursen visar men någonstans är något inte som det ska. 
Tack för en bra kurs.


--------------Min kod:

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace razorpage.Pages.Categories
{
    [BindProperties]

    public class EditModel : PageModel
    {

        private readonly ApplicationDbContext _db;
        public Category Category { get; set; }

        public EditModel(ApplicationDbContext db)
        {

            _db = db;
        }

        public void OnGet(int? Id)
        {
            if (Id != null && Id != 0)
            {
                Category = _db.Categories.Find(Id);
            }

        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                _db.Categories.Update(Category);
                _db.SaveChanges();
                //            TempData["success"]="Category was updated successfully";
                return RedirectToPage("Index");
            }
           
            return Page();
        }
    }
}



