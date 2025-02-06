using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.UI.Common
{
    public abstract class BaseStoreView: StoreView
    {
        private bool _exitView = false;
        protected virtual string Title(string title)
        {
            return title +"\r\n" + Seperator("-", title.Length);
        }

        protected virtual string Seperator(string token, int length)
        {
            var sep = "";
            for(var i=0;i<length;i++) { 
                sep += token;
            }
            return sep + "\r\n";
        }

        protected string Banner(string content)
        {
            return Seperator("=",content.Length) + content +"\r\n" + Seperator("=",content.Length);
        }

        protected void Render(string content)
        {
            System.Console.Write(content + "\r\n");
        }

        public virtual void OnStart(StoreContext context, ViewManager viewManager)
        {

        }


        public bool CanExitView()
        {
            return _exitView;
        }

        protected void CloseView()
        {
            _exitView = true;
        }

    }
}
