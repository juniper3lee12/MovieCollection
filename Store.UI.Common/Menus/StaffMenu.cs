using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.UI.Common.Menus
{
    public class StaffMenu: BaseStoreView
    {
        public override void OnStart(StoreContext context, ViewManager viewManager)
        {
            Render(Title("Staff Menu"));
            Render("1. Add DVDs to system");
            Render("2. Remove DVDs from system");
            Render("3. Register a new member to system");
            Render("4. Remove a registered member from system");
            Render("5. Find a member contact phone number, given the member's name");
            Render("6. Find members who are currently renting a particular movie");
            Render("0. Return to main menu");
            Render("Enter your choice ==>");
            var choice = System.Console.ReadLine();

            switch(choice)
            {
                case "1":
                    viewManager.SwitchView(viewManager.StaffMenuAddDvd);
                    break;
                case "2":
                    viewManager.SwitchView(viewManager.StaffMenuRemoveDvd);
                    break;
                case "3":
                    viewManager.SwitchView(viewManager.StaffMenuRegisterNewMember);
                    break;
                case "4":
                    viewManager.SwitchView(viewManager.StaffMenuRemoveMember);
                    break;
                case "5":
                    viewManager.SwitchView(viewManager.StaffMenuFindPhoneNumber);
                    break;
                case "6":
                    viewManager.SwitchView(viewManager.StaffMenuFindMember);
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
