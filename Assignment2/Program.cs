using Store.Common;
using Store.UI.Common;
using Store.UI.Common.Views;
using Store.UI.Common.Menus;
using Store.UI.Common.Staff;
using System.ComponentModel.DataAnnotations;

namespace Assignment2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var storeContext = new StoreContext();
            storeContext.Movies = new MovieCollection(1000, new MovieHashKeyProvider());
            storeContext.TopMovies = new TopMovieQueue(3);
            storeContext.Members = new MemberCollection(5);


            storeContext.Members.AddMember(new Member("1", "1", "1", "1"));
            var m1 = new Movie("Movie");
            m1.AddNewCopies(5);
            var m2 = new Movie("Mock2");
            m2.AddNewCopies(5);
            var m3 = new Movie("Mock3");
            m3.AddNewCopies(5);
            var m4 = new Movie("Mock4");
            m4.AddNewCopies(5);
            var m5 = new Movie("Mock5");
            m5.AddNewCopies(5);

            SimulateUsage(m1, 10);
            SimulateUsage(m2, 7);
            SimulateUsage(m3, 5);
            SimulateUsage(m4, 20);
            SimulateUsage(m5 , 10);

            storeContext.Movies.Add(m1);
            storeContext.Movies.Add(m2);
            storeContext.Movies.Add(m3);
            storeContext.Movies.Add(m4);
            storeContext.Movies.Add(m5);

            var viewManager = new ViewManager(storeContext);

            viewManager.RegisterView(viewManager.MainMenu, new StoreMainMenu());
            viewManager.RegisterView(viewManager.LoginMenu, new LoginMenu());
            viewManager.RegisterView(viewManager.MemberMenu, new MemberMenu());
            viewManager.RegisterView(viewManager.StaffLogin, new StaffLogin());
            viewManager.RegisterView(viewManager.MemberLogin, new MemberLogin());


            viewManager.RegisterView(viewManager.StaffMenu, new StaffMenu());
            viewManager.RegisterView(viewManager.StaffMenuAddDvd, new StaffAddDVD());
            viewManager.RegisterView(viewManager.StaffMenuRemoveDvd, new StaffRemoveDVD());
            viewManager.RegisterView(viewManager.StaffMenuRegisterNewMember, new StaffRegisterMember());
            viewManager.RegisterView(viewManager.StaffMenuRemoveMember, new StaffRemoveMember());
            viewManager.RegisterView(viewManager.StaffMenuFindMember, new StaffFindMember());
            viewManager.RegisterView(viewManager.StaffMenuFindPhoneNumber, new StaffFindMemberByPhone());


            viewManager.RegisterView(viewManager.MemberMenuBrowseMovies, new MemberBrowseMovies());
            viewManager.RegisterView(viewManager.MemberMenuDisplayAllDetailsOfMovies, new MemberDisplayDetailsOfMovie());
            viewManager.RegisterView(viewManager.MemberMenuBurrowMovieDVD, new MemberBurrowDVD());
            viewManager.RegisterView(viewManager.MemberMenuReturnMovieDVD, new MemberReturnDVD());
            viewManager.RegisterView(viewManager.MemberMenuListCurrentBurrowedMovies, new MemberListBurrowedDVDs());
            viewManager.RegisterView(viewManager.MemberMenuDisplayTopMovies, new MemberDisplayTopMovies());

            viewManager.SwitchView(viewManager.MainMenu);

            viewManager.Start();
        }

        protected static void SimulateUsage(Movie movie, int usage)
        {
            var i = 0;
            while (i < usage)
            {
                movie.BurrowCopies(1);
                movie.ReturnCopies(1);
                i++;
            }
        }
    }
}
