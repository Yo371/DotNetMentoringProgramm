using NUnit.Framework;

namespace FileSystemVisitorLibrary
{
    internal class TestsFileSystemVisitor
    {
        [Test]
        public void CheckNullPathArgument()
        {
            Assert.Throws<ArgumentNullException>(() => new FileSystemVisitorConsole(null));
        }

        [Test]
        public void CheckEmptyPathArgument()
        {
            Assert.Throws<ArgumentException>(() => new FileSystemVisitorConsole(string.Empty));
        }

        [Test]
        public void CheckNotExistedPathArgument()
        {
            Assert.Throws<DirectoryNotFoundException>(()=> new FileSystemVisitorConsole("fdg").GetAllItems().ToList());
        }

        [Test]
        public void CheckFilterNullArgument()
        {
            Assert.Throws<ArgumentNullException>(() => new FileSystemVisitorConsole(@"C:\TestVisitor\", null).GetAllFilteredItems().ToList());
        }
    }
}
