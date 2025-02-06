using Store.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.UI.Common.Views
{
    public class MemberLogin : BaseStoreView
    {
        public override void OnStart(StoreContext context, ViewManager viewManager)
        {
            var firstName = "";
            var lastName = "";
            var password = "";
            Render(Title("Member login"));
            Render("Enter first name");
            firstName = Console.ReadLine();
            Render("Enter last name:");
            lastName = Console.ReadLine();
            Render("Enter the password");
            password = Console.ReadLine();

            var currentMemberDetails = new Member(firstName, lastName,"", "");
            var foundMember = context.Members.FindMember(new Member(firstName, lastName,"", password));
            if (foundMember == null)
            {
                Render("ERR No such with first name and last name provided.");
                return;
            }
            if (!foundMember.Authenticate(firstName,lastName,password))
            {
                Render("ERR Login details are incorrect");
                return;
            }
            context.SetActiveMember(foundMember);
            viewManager.SwitchView(viewManager.MemberMenu);
        }
    }
}
