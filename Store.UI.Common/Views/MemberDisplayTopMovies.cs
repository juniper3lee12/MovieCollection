using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.UI.Common.Views
{
    public class MemberDisplayTopMovies: BaseStoreView
    {
        public override void OnStart(StoreContext context, ViewManager viewManager)
        {
            Render(Title("Top 3 movies"));
            var movies =context.TopMovies.GetMovies();

            Render("Title\t\tBurrowed Copies");
            var current = movies.GetHead();
            while (current != null)
            {
                Render($"{current.Data.Title}\t\t{current.Data.BurrowedCopies}");
                current = current.Next;
            }

            var choice = Console.ReadLine();
            viewManager.SwitchView(viewManager.MemberMenu);
        }
    }
}
