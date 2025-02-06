using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Common
{
    public class MovieCollection
    {
        private LinkedList [] _buckets;
        private int _size;
        private int _count;
        private HashKeyProvider _hashProvider;


        public int Size { get { return _size; } }
        public int Count { get { return _count; } }

        public MovieCollection(int size, HashKeyProvider hashKeyProvider)
        {
            _size = size;
            _count = 0;
            _buckets = new LinkedList[_size];
            _hashProvider = hashKeyProvider;
        }

        public bool Add(Movie movie)
        {
            var key = _hashProvider.CreateKey(movie, this);

            if(key > _size)
            {
                return false;
            }
            if (_buckets[key] == null)
            {
                _buckets[key] = new LinkedList();
            }
            var foundMovieNode = _buckets[key].Find(movie);
            if(foundMovieNode != null)
            {
                foundMovieNode.Data.AddNewCopies(movie.TotalCopies);
                return true;
            }
            _buckets[key].Add(movie);
            _count++;
            return true;
        }

        public bool Remove(Movie item)
        {
            var removed = true;
            var key = _hashProvider.CreateKey(item,this);
            if(key > _size)
            {
                return false;
            }
            if (_buckets[key] == null)
            {
                return false;
            }
            var bucket = _buckets[key];
            if(bucket.Count() < 1)
            {
                return false;
            }
            var foundMovie = bucket.Find(item);
            if(foundMovie == null)
            {
                return false;
            }
            if(foundMovie.Data.TotalCopies < 1)
            {
                bucket.Remove(item);
                _count--;
            }
            return removed;
        }

        public void RemoveCopies(Movie movie, int copiesToRemove)
        {
            if(!CanRemoveMovie(movie, copiesToRemove))
            {
                return;
            }
            movie.RemoveCopies(copiesToRemove);
            if(movie.TotalCopies == 0)
            {
                System.Console.WriteLine("WARN Removed the movie from the collection");
                Remove(movie);
                return;
            }

        }

        public bool CanRemoveMovie(Movie movie, int copiesToRemove)
        {
            if(movie.TotalCopies == movie.AvailableCopies)
            {
                return true;
            }
            if(movie.TotalCopies - copiesToRemove <= -1)
            {
                return false;
            }
            return true;
        }


        public Movie? Search(Movie item)
        {
            var key = _hashProvider.CreateKey(item,this);
            if(key > _size)
            {
                return null;
            }
            if (_buckets[key] == null)
            {
                return null;
            }
            var movieNode = _buckets[key].Find(item);
            if(movieNode == null)
            {
                return null;
            }
            return movieNode.Data;
        }
  

        public string Report()
        {
            var report = "";
            report += "Title\t\tT\tA\tB\r\n";
            for(var i = 0; i < _size; i++)
            {
                if (_buckets[i] != null)
                {
                    var head = _buckets[i].GetHead();
                    while (head != null)
                    {
                        report += $"{head.Data.Title}\t\t{head.Data.TotalCopies}\t{head.Data.AvailableCopies}" +
                            $"\t{head.Data.BurrowedCopies}" + "\r\n";
                        head = head.Next;
                    }
                }
            }
            report += "\r\nT - Total copies\r\nA - Available copies\r\nB - Burrowed copies\r\n";
            return report;
        }

    }
}
