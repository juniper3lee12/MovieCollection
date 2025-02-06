using Store.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.UI.Common.Views
{
    public class MemberDisplayDetailsOfMovie: BaseStoreView
    {
        public override void OnStart(StoreContext context, ViewManager viewManager)
        {
            Render(Title("Details of Movie"));

            Render("Enter movie title");
            var title = System.Console.ReadLine();

            var movie = context.Movies.Search(new Movie(title));

            Render("Results");
            Render($"Title: {movie.Title}");
            Render($"Total copies: {movie.TotalCopies}");
            Render($"Available copies: {movie.AvailableCopies}");
            Render($"Burrowed copies: {movie.BurrowedCopies}");

            Render("Please press enter to go back");
            var choice = System.Console.ReadLine();

            viewManager.SwitchView(viewManager.MemberMenu);
        }
    }
}
