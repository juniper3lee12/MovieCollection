using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.UI.Common.Menus
{
    public class MemberMenu: BaseStoreView
    {
        public override void OnStart(StoreContext context, ViewManager viewManager)
        {
            Render(Title("Member Menu"));
            Render("1. Browse all the movies");
            Render("2. Display all the information about a movie, given the tilte of the movie");
            Render("3. Borrow a movie DVD");
            Render("4. Return a movie DVD");
            Render("5. List current burrowing movies");
            Render("6. Display the top 3 movies rented by the members");
            Render("0. Return to main menu");
            Render("Enter your choice ==>");
            var choice = System.Console.ReadLine();

            switch (choice)
            {
                case "1":
                    viewManager.SwitchView(viewManager.MemberMenuBrowseMovies);
                    break;
                case "2":
                    viewManager.SwitchView(viewManager.MemberMenuDisplayAllDetailsOfMovies);
                    break;
                case "3":
                    viewManager.SwitchView(viewManager.MemberMenuBurrowMovieDVD);
                    break;
                case "4":
                    viewManager.SwitchView(viewManager.MemberMenuReturnMovieDVD);
                    break;
                case "5":
                    viewManager.SwitchView(viewManager.MemberMenuListCurrentBurrowedMovies);
                    break;
                case "6":
                    viewManager.SwitchView(viewManager.MemberMenuDisplayTopMovies);
                    break;
                case "0":
                    viewManager.SwitchView(viewManager.MainMenu);
                    break;
                default:
                    break;
            }
        }
    }
}
