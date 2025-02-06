using Store.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.UI.Common.Views
{
    public class MemberReturnDVD: BaseStoreView
    {
        public override void OnStart(StoreContext context, ViewManager viewManager)
        {
            Render(Title("Return DVDs"));
            Render("Please enter DVD title:");
            var title = Console.ReadLine();
            var currentMovie = new Movie(title);
            var foundMovie = context.Movies.Search(currentMovie);

            if(foundMovie == null)
            {
                Render("ERR A movie with the provided title could not be found.");
                return;
            }
            foundMovie.ReturnCopies(1);
            context.GetMember().ReturnMovie(foundMovie);

            Render("Press enter to go back to the main menu");
            var choice = System.Console.ReadLine();
            viewManager.SwitchView(viewManager.MemberMenu);
        }
    }
}
