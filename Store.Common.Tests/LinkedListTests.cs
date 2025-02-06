using System.ComponentModel.DataAnnotations;

namespace Store.Common.Tests2
{
    public class LinkedListTests
    {
        [Fact]
        public void Is_Inserted()
        {
            var list = new LinkedList();
            list.Add(new Movie("Test1"));
            Assert.Equal(1, list.Count());
        }

        [Fact]
        public void Is_Head_Removed()
        {
            var list = new LinkedList();
            var movie = new Movie("Test1");
            list.Add(movie);
            Assert.Equal(1, list.Count());
            list.Remove(movie);
            Assert.Equal(0, list.Count());
        }

        [Fact]
        public void Is_Tail_Removed()
        {
            var list = new LinkedList();
            list.Add(new Movie("Test1"));
            list.Add(new Movie("Test2"));
            list.Remove(new Movie("Test1"));
            Assert.Equal(1, list.Count());
        }

        [Fact]
        public void Is_Node_Removed_From_Empty_List()
        {
            var list = new LinkedList();
            list.Remove(new Movie("Test1"));
            Assert.Equal(0, list.Count());
        }

        [Fact]
        public void Is_Node_Removed_From_Middle()
        { 
            var list = new LinkedList();
            list.Add(new Movie("Test1"));
            list.Add(new Movie("Test2"));
            list.Add(new Movie("Test3"));
            Assert.Equal(3, list.Count());

            list.Remove(new Movie("Test2"));
            Assert.Equal(2, list.Count());
        }

        [Fact]
        public void Is_Node_Found()
        {
            var list = new LinkedList();
            list.Add(new Movie("Test1"));
            list.Add(new Movie("Test2"));
            list.Add(new Movie("Test3"));
            var foundMovie = list.Find(new Movie("Test1"));
            Assert.NotNull(foundMovie);
        }

        [Fact]
        public void Is_Last_Node_Found()
        {
            var list = new LinkedList();
            list.Add(new Movie("Test1"));
            list.Add(new Movie("Test2"));
            list.Add(new Movie("Test3"));
            var fouindMovie = list.Find(new Movie("Test2"));
            Assert.NotNull(fouindMovie);
        }
    }
}