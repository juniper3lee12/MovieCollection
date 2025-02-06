using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Store.Common
{
    public class TopMovieQueue
    {
        private LinkedList _movies;
        private int _queueSize;
        public TopMovieQueue(int queueSize)
        {
            _movies = new LinkedList();
            _queueSize = queueSize;
        }

        public void Enqueue(Movie movie)
        {
            var head = _movies.GetHead();
            var foundMovie = _movies.Find(movie);
            if (foundMovie != null)
            {
                // If the movie is already in the queue do nothing
                return;
            }
            if (head == null)
            {
                _movies.Add(movie);
                return;
            }
            if (head.Data.BurrowedCopies  <= movie.BurrowedCopies)
            {
                _movies.Add(movie);
            }
            else
            {
                InsertToHighestPosition(head, movie);
            }
            if (_movies.Count() > 3)
            {
                _movies.RemoveTail();
            }
        }

        public void InsertToHighestPosition(MovieLinkedListNode current, Movie movie)
        {
            var found = false;
            while ((current != null) && (found == false))
            {
                if(current.Data.BurrowedCopies < movie.BurrowedCopies)
                {
                    found = true;
                }
                else
                {
                    current = current.Next;
                }
            }

            if(current == null)
            {
                _movies.AddTail(movie);
                return;
            }
            var newNode = new MovieLinkedListNode()
            {
                Data = movie
            };
            _movies.InsertAtNode(current, newNode);
        }

        public LinkedList GetMovies()
        {
            return _movies;
        }
    }
}
