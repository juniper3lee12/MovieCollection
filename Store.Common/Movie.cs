using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Common
{
    public class Movie
    {
        public string Title
        {
            get
            {
                return _title;
            }
        }
        public int TotalCopies
        {
            get
            {
                return _totalCopies;

            }
        }
        public int AvailableCopies
        {
            get
            {
                return _availableCopies;
            }
        }

        public int BurrowedCopies
        {
            get
            {
                return _burrowedCount;
            }
        }

        private string _title;
        private int _totalCopies;
        private int _availableCopies;
        private int _burrowedCount;

        public Movie(string title)
        {
            _title = title;
            _totalCopies = 0;
            _availableCopies = 0;
            _burrowedCount = 0;
        }

        public void AddNewCopies(int numberOfCopies)
        {
            _totalCopies += numberOfCopies;
            _availableCopies+= numberOfCopies;
        }

        public void BurrowCopies(int numberOfCopies)
        {
            if(CanBurrowCopies(numberOfCopies) < 0)
            {
                Console.WriteLine("ERR! Cannot burrow copies");
            }
            _availableCopies-=numberOfCopies;
            _burrowedCount += numberOfCopies;
        }

        public void ReturnCopies(int numberOfCopies)
        {
            _availableCopies += numberOfCopies;
        }

        public int CanBurrowCopies(int numberOfCopies)
        {
            return _availableCopies - numberOfCopies;
        }

        public bool RemoveCopies(int totalCopies)
        {
            if(_availableCopies - totalCopies < -1)
            {
                return false;
            }
            _availableCopies -= totalCopies;
            _totalCopies -= totalCopies;
            return true;
        }
    }
}
