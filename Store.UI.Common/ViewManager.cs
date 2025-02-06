using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.UI.Common
{
    public class ViewManager
    {
        public readonly int StaffMenuAddDvd = 0;
        public readonly int StaffMenuRemoveDvd = 1;
        public readonly int StaffMenuRegisterNewMember = 2;
        public readonly int StaffMenuRemoveMember = 3;
        public readonly int StaffMenuFindPhoneNumber = 4;
        public readonly int StaffMenuFindMember = 5;
        public readonly int MainMenu = 6;
        public readonly int StaffLogin = 7;
        public readonly int MemberLogin = 8;
        public readonly int LoginMenu = 9;
        public readonly int MemberMenu = 10;
        public readonly int MemberMenuBrowseMovies = 11;
        public readonly int MemberMenuDisplayAllDetailsOfMovies = 12;
        public readonly int MemberMenuBurrowMovieDVD = 13;
        public readonly int MemberMenuReturnMovieDVD = 14;
        public readonly int MemberMenuListCurrentBurrowedMovies = 15;
        public readonly int MemberMenuDisplayTopMovies = 16;
        public readonly int StaffMenu = 17;

        private StoreView[] _views;
        private StoreView? _currentView;
        private StoreContext _context;

        public ViewManager(StoreContext context)
        {
            _views = new StoreView[18];
            _context = context;
        }

        public void RegisterView(int viewId, StoreView view)
        {
            _views[viewId] = view;
        }

        public void SwitchView(int viewId)
        {
            if (_views[viewId] == null)
            {
                throw new Exception("View does not exist");
            }
            _currentView = _views[viewId];
        }

        public void Start()
        {
            _currentView?.OnStart(_context, this);
            while (!_currentView.CanExitView())
            {
                _currentView.OnStart(_context,this);
            }
        }
    }
}
