using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.UI.Common.Views
{
    public class MemberListBurrowedDVDs: BaseStoreView
    {
        public override void OnStart(StoreContext context, ViewManager viewManager)
        {
            Render(Title("List all burrowed movies"));
            var currentMember = context.GetMember();

            Render(currentMember.ReportBurrowedMovies());
            Render("Please press enter to go back to the member menu");
            var wait = Console.ReadLine();
            viewManager.SwitchView(viewManager.MemberMenu);
        }
    }
}
