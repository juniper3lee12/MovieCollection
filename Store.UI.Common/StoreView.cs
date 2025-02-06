using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.UI.Common
{
    public interface StoreView
    {
        public void OnStart(StoreContext context,ViewManager viewManager);
        public bool CanExitView();
    }
}
