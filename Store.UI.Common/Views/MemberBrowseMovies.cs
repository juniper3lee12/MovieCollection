using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.UI.Common.Views
{
    public class MemberBrowseMovies: BaseStoreView
    {
        public override void OnStart(StoreContext context, ViewManager viewManager)
        {
            Render(Title("Browse Movies"));

            Render(context.Movies.Report());

            Render("Please press enter to go back");
            var choice = System.Console.ReadLine();
            viewManager.SwitchView(viewManager.MemberMenu);
        }
    }
}
