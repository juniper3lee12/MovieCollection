using Store.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.UI.Common.Staff
{
    public class StaffRegisterMember : BaseStoreView
    {
        public override void OnStart(StoreContext context, ViewManager viewManager)
        {
            Render(Title("Register Member"));
            Render("Enter first name:");
            var firstName = System.Console.ReadLine();
            Render("Enter last name:");
            var lastName = System.Console.ReadLine();
            Render("Enter phone number");
            var phoneNumber = System.Console.ReadLine();

            Render("Enter password:");
            var password = System.Console.ReadLine();

            var member = new Member(firstName, lastName,phoneNumber, password);

            context.Members.AddMember(member);
            viewManager.SwitchView(viewManager.StaffMenu);
        }
    }
}
