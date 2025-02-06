using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.UI.Common.Staff
{
    public class StaffLogin : BaseStoreView
    {
        public override void OnStart(StoreContext context, ViewManager viewManager)
        {
            Render(Title("Staff login"));
            Render("Please enter username:");
            var username = System.Console.ReadLine();
            Render("Please enter password:");
            var password = System.Console.ReadLine();

            if((username =="staff")&&(password == "today123")){
                viewManager.SwitchView(viewManager.StaffMenu);
            } else
            {
                Render("ERR The username and password is incorrect");
            }
        }
    }
}
