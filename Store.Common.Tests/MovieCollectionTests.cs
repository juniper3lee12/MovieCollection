using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Common.Tests
{
    public class MovieCollectionTests
    {
        [Fact]
        public void Is_Added()
        {
            var hashTable = new MovieCollection(10, new MovieHashKeyProvider());
            hashTable.Add(new Movie("Test"));
            Assert.Equal(1, hashTable.Count);
        }
        [Fact]
        public void Is_Multiple_Added()
        {
            var hashTable = new MovieCollection(10, new MovieHashKeyProvider());
            hashTable.Add(new Movie("Cujo"));
            hashTable.Add(new Movie("Kill a mocking bird"));
            Assert.Equal(2, hashTable.Count);
        }

        [Fact]
        public void Is_Removed()
        {
            var hashTable = new MovieCollection(10, new MovieHashKeyProvider());
            var movie = new Movie("Test");
            movie.AddNewCopies(1);
            hashTable.Add(movie);
            Assert.Equal(1, hashTable.Count);
            hashTable.Remove(movie);
            Assert.Equal(1, hashTable.Count);
        }

        [Fact]
        public void Is_Movie_Copy_Removed_When_Zero()
        {
            var hashTable = new MovieCollection(10, new MovieHashKeyProvider());
            var m1 = new Movie("m1");
            m1.AddNewCopies(1);
            hashTable.Add(m1);
            Assert.Equal(1, hashTable.Count);
            hashTable.RemoveCopies(m1,1);
            Assert.Equal(0, hashTable.Count);
        }

        [Fact]
        public void Is_Movie_Copy_Removed_When_NonZero()
        {
            var hashTable = new MovieCollection(10, new MovieHashKeyProvider());
            var m1 = new Movie("m1");
            m1.AddNewCopies(10);
            hashTable.Add(m1);
            Assert.Equal(1, hashTable.Count);
            hashTable.RemoveCopies(m1, 1);
            Assert.Equal(1, hashTable.Count);
            Assert.Equal(9, m1.AvailableCopies);
        }
    }
}
