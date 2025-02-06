using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Store.Common.Tests
{
    public class TopMovieQueueTests
    {
        [Fact]
        public void Is_Limit_Checked()
        {
            var queue = new TopMovieQueue(3);

            var m1 = new Movie("Test1");
            m1.BurrowCopies(1);
            var m2 = new Movie("Test2");
            m2.BurrowCopies(1);
            var m3 = new Movie("Test3");
            m3.BurrowCopies(1);
            var m4 = new Movie("Test4");
            m4.BurrowCopies(1);
            queue.Enqueue(m1);
            queue.Enqueue(m2);
            queue.Enqueue(m3);
            Assert.Equal(3, queue.GetMovies().Count());
            queue.Enqueue(m4);
            Assert.Equal(3, queue.GetMovies().Count());
        }

        [Fact]
        public void Is_Top3__Movies()
        {
            var m1 = new Movie("m1");
            m1.AddNewCopies(5);
            m1.BurrowCopies(1);
            var m2 = new Movie("m2");
            m2.AddNewCopies(5);
            m2.BurrowCopies(3);
            var m3 = new Movie("m3");
            m3.AddNewCopies(5);
            m3.BurrowCopies(4);
            var m4 = new Movie("m4");
            m4.AddNewCopies(5);
            m4.BurrowCopies(5);
            m4.ReturnCopies(5);
            m4.BurrowCopies(4);
            var m5 = new Movie("m5");
            m5.AddNewCopies(5);
            m5.BurrowCopies(4);
            m5.ReturnCopies(4);
            m5.BurrowCopies(2);

            var queue = new TopMovieQueue(3);
            queue.Enqueue(m1);
            queue.Enqueue(m2);
            queue.Enqueue(m3);
            queue.Enqueue(m4);
            queue.Enqueue(m5);
            queue.Enqueue(m1);
            var queuedMovies = queue.GetMovies(); 
            Assert.Equal(3, queuedMovies.Count());

            var current = queuedMovies.GetHead();
            var movieTitles = new string[3];
            var index = 0;
            while(current != null)
            {
                movieTitles[index++] = current.Data.Title;
                current = current.Next;
            }
            Assert.Equal("m4", movieTitles[0]);
            Assert.Equal("m5", movieTitles[1]);
            Assert.Equal("m3", movieTitles[2]);
        }
    }
}
