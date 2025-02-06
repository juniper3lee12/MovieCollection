using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.UI.Common.Menus
{
    public class LoginMenu: BaseStoreView
    {
        public override void OnStart(StoreContext context, ViewManager viewManager)
        {
            Render(Title("Login"));
            Render("1. Login as staff");
            Render("2. Login as member");
            var choice = System.Console.ReadLine();
            switch (choice)
            {
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
