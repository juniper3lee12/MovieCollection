using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.UI.Common.Menus
{
    public class StoreMainMenu : BaseStoreView
    {
        public override void OnStart(StoreContext context,ViewManager viewManager)
        {
            Render(Banner("COMMUNITY LIBRARY MOVIE DVD MANAGEMENT SYSTEM"));
            Render(Title("Main Menu"));
            Render("Select from the following:");
            Render("1. Staff");
            Render("2. Member");
            Render("0. End the program");
            Render("Enter your choice ==>");
            var choice = System.Console.ReadLine();
            switch(choice)
            {
                case "0":
                    CloseView();
                    break;
                case "1":
                    viewManager.SwitchView(viewManager.StaffLogin);
                    break;
                case "2":
                    viewManager.SwitchView(viewManager.MemberLogin);
                    break;
                default:
                    break;
            }
        }
    }
}
