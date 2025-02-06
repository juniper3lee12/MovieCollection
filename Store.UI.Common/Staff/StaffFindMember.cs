using Store.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.UI.Common.Staff
{
    public class StaffFindMember : BaseStoreView
    {
        public override void OnStart(StoreContext context, ViewManager viewManager)
        {
            Render(Title("Find Members renting a particular movie"));
            Render("Please enter title:");
            var title = Console.ReadLine();

            var members = context.Members.FindMembersByMovie(title);
            Render(members);
          
            var choice = System.Console.ReadLine();
            viewManager.SwitchView(viewManager.StaffMenu);
        }
    }
}
