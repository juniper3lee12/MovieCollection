using Store.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.UI.Common.Staff
{
    public class StaffFindMemberByPhone : BaseStoreView
    {
        public override void OnStart(StoreContext context, ViewManager viewManager)
        {
            Render(Title("Find a member's by contact phone"));
            Render("Please enter the first name:");
            var firstName = Console.ReadLine();
            Render("Please enter the last name:");
            var lastName = Console.ReadLine();


            var found = context.Members.FindMember(new Member(firstName,lastName,"",""));
            if (found==null)
            {
                Render("ERR Could not find a member");
            } else
            {
                Render("Phone number: " + found.PhoneNumber);
            }

            var choice = System.Console.ReadLine();           
            viewManager.SwitchView(viewManager.StaffMenu);
        }
    }
}
