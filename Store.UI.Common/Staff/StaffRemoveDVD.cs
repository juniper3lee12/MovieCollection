using Store.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.UI.Common.Staff
{
    public class StaffRemoveDVD: BaseStoreView
    {
        public override void OnStart(StoreContext context, ViewManager viewManager)
        {
            Render(Title("Remove DVD"));
            Render("Enter title to remove");
            var title = System.Console.ReadLine();
            var movie = new Movie(title);
            var foundMovie = context.Movies.Search(movie);
           
            if(foundMovie == null)
            {
                Render("ERR The movie was not found");
                viewManager.SwitchView(viewManager.StaffMenu);
                return;
            }

            Render("Please enter the number of copies to remove:");
            var numCopies = System.Console.ReadLine();

            int.TryParse(numCopies, out var copies);

            context.Movies.RemoveCopies(foundMovie, copies); 

            Render("Please press enter to go back");
            var choice = System.Console.ReadLine();
            viewManager.SwitchView(viewManager.StaffMenu);
        }
    }
}
