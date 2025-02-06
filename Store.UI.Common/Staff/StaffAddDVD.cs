using Store.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.UI.Common.Staff
{
    public class StaffAddDVD : BaseStoreView
    {
        public override void OnStart(StoreContext context, ViewManager viewManager)
        {
            Render(Title("Add DVD"));
            Render("Movie title:");
            var title = System.Console.ReadLine();
            Render("Number of movies");
            var countStr = System.Console.ReadLine();
            if(!int.TryParse(countStr, out var count))
            {
                System.Console.WriteLine("ERR! You need to enter a number");
                return;
            }
            var movie = new Movie(title);
            movie.AddNewCopies(count);
            context.Movies.Add(movie);

            var choice = System.Console.ReadLine();
            viewManager.SwitchView(viewManager.StaffMenu);
        }
    }
}
