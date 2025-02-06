using Store.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.UI.Common.Views
{
    public class MemberBurrowDVD: BaseStoreView
    {
        public override void OnStart(StoreContext context, ViewManager viewManager)
        {
            Render(Title("Burrow DVD"));
            Render("Please enter name of the movie: ");
            var title = Console.ReadLine();
            var currentMovie = new Movie(title);
            var foundMovie = context.Movies.Search(currentMovie);
            if (foundMovie == null)
            {
                Render("ERR Unable to find a movie with the provided title");
                return;
            }
            if (foundMovie.CanBurrowCopies(1) <0)
            {
                Render("ERR Not enough copies of the movie");
                return;
            }
            foundMovie.BurrowCopies(1);
            context.GetMember().BurrowMovie(foundMovie);
            context.TopMovies.Enqueue(foundMovie);

            Render("Successfully burrowed");

            Render("Please press enter");
            var choice = System.Console.ReadLine();
            viewManager.SwitchView(viewManager.MemberMenu);
        }
    }
}
