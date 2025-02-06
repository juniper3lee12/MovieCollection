using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Common
{
    public class Member
    {
        private LinkedList _burrowedMovies = new();
        private string _firstName;
        private string _lastName;
        private string _phoneNumber;
        private string _password;

        public string FirstName
        {
            get
            {
                return _firstName;
            }
        }
        public string LastName
        {
            get
            {
                return _lastName;
            }
        }

        public string PhoneNumber
        {
            get
            {
                return _phoneNumber;
            }
        }

        public Member(string firstName, string lastName,string phoneNumber, string password)
        {
            _firstName = firstName;
            _lastName = lastName;
            _password = password;
            _burrowedMovies = new LinkedList();
            _phoneNumber = phoneNumber;
        }

        public void BurrowMovie(Movie movie)
        {
            if(_burrowedMovies.Count() < 5)
            {
                _burrowedMovies.Add(movie);
                return;
            }
        }

        public void ReturnMovie(Movie movie)
        {
            _burrowedMovies.Remove(movie);
        }

        public LinkedList GetBurrowedMovies()
        {
            return _burrowedMovies;
        }
        public bool Authenticate(string firstName, string lastName, string password)
        {
            if((_firstName == firstName) && (_lastName == lastName)
                    && ( _password == password))
            {
                return true;
            }
            return false;
        }

        public bool IsEqual(Member other)
        {
            return _firstName.Equals(other._firstName) && _lastName.Equals(other._lastName);
        }

        public string ReportBurrowedMovies()
        {
            var report = "";
            var movieNode = _burrowedMovies.GetHead();
            while (movieNode != null)
            {
                report += movieNode.Data.Title +"\r\n";
                movieNode = movieNode.Next;
            }
            return report;
        }

        public bool CanBurrowMovies()
        {
            return _burrowedMovies.Count() < 5;
        }
    }
}
