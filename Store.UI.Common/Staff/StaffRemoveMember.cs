using Store.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.UI.Common.Staff
{
    public class StaffRemoveMember: BaseStoreView
    {
        public override void OnStart(StoreContext context, ViewManager viewManager)
        {
            Render(Title("Remove member"));
            Render("Please enter first name: ");
            var firstName = Console.ReadLine();
            Render("Please enter last name: ");
            var lastName = Console.ReadLine();
            
            var currentMember = new Member(firstName, lastName,"","");

            var foundMember = context.Members.FindMember(currentMember);

            context.Members.RemoveMember(foundMember);

            Render("Please press enter to go back");
            var choice = System.Console.ReadLine();
            viewManager.SwitchView(viewManager.StaffMenu);
        }
    }
}
