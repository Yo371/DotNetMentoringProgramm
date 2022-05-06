namespace FileSystemVisitorLibrary
{

    public interface IFileSystemVisitor
    {
        event EventHandler? StartEvent;
        event EventHandler? EndEvent;
        event EventHandler<FileSystemInfo>? FileFoundEvent;
        event EventHandler<FileSystemInfo>? DirectoryFoundEvent;
        event EventHandler<FileSystemInfo>? FilteredFileFoundEvent;
        event EventHandler<FileSystemInfo>? FilteredDirectoryFoundEvent;
        IEnumerable<FileSystemInfo> GetAllItems();
        IEnumerable<FileSystemInfo> GetAllFilteredItems();
        void Abort();
        void SkipNext();
    }

    public enum SearchStrategy
    {
        Continiue, Skip, Stop
    }
    public class FileSystemVisitorConsole : IFileSystemVisitor
    {
        private readonly DirectoryInfo _directory;
        private readonly Predicate<FileSystemInfo>? _filter;

        public event EventHandler? StartEvent;
        public event EventHandler? EndEvent;
        public event EventHandler<FileSystemInfo>? FileFoundEvent;
        public event EventHandler<FileSystemInfo>? DirectoryFoundEvent;
        public event EventHandler<FileSystemInfo>? FilteredFileFoundEvent;
        public event EventHandler<FileSystemInfo>? FilteredDirectoryFoundEvent;

        private SearchStrategy _searchStrategy = SearchStrategy.Continiue;

        public FileSystemVisitorConsole(string path, Predicate<FileSystemInfo>? filter) : this(path)
        {
            _filter = filter;
        }

        public FileSystemVisitorConsole(string path)
        {
            _directory = new DirectoryInfo(path);
        }

        public IEnumerable<FileSystemInfo> GetAllItems()
        {
            StartEvent?.Invoke(this, EventArgs.Empty);
            foreach (var item in GetAllFilesViaYield(_directory))
            {
                RunEvent(item);
                if (_searchStrategy == SearchStrategy.Stop) yield break;
                if (_searchStrategy == SearchStrategy.Skip) continue;
                yield return item;
            }
            EndEvent?.Invoke(this, EventArgs.Empty);
        }

        public IEnumerable<FileSystemInfo> GetAllFilteredItems()
        {
            StartEvent?.Invoke(this, EventArgs.Empty);
            ArgumentNullException.ThrowIfNull(_filter);
            foreach (var item in GetAllFilesViaYield(_directory))
            {
                RunEvent(item, true);
                if (_filter(item) && _searchStrategy == SearchStrategy.Skip) continue; 
                if (_filter(item) && _searchStrategy == SearchStrategy.Stop) yield break;
                yield return item;
            }
            EndEvent?.Invoke(this, EventArgs.Empty);
        }

        private IEnumerable<FileSystemInfo> GetAllFilesViaYield(DirectoryInfo directoryInfo)
        {
            var itemsInDirectory = directoryInfo.EnumerateFileSystemInfos();
            foreach (var item in itemsInDirectory)
            {
                yield return item;
                if (item is DirectoryInfo directory)
                {
                    foreach (var itemInDirectory in GetAllFilesViaYield(directory))
                    {
                        yield return itemInDirectory;
                    }
                }
            }
        }

        public void Abort()
        {
            _searchStrategy = SearchStrategy.Stop;
        }

        public void SkipNext()
        {
            _searchStrategy = SearchStrategy.Skip;
        }

        private void RunEvent(FileSystemInfo item, bool onlyFiltered = false)
        {

            if (item is DirectoryInfo)
            {
                if (!onlyFiltered) DirectoryFoundEvent?.Invoke(this, item);
                if (_filter != null && _filter(item)) FilteredDirectoryFoundEvent?.Invoke(this, item);
            }
            else
            {
                if (!onlyFiltered) FileFoundEvent?.Invoke(this, item);
                if (_filter != null && _filter(item)) FilteredFileFoundEvent?.Invoke(this, item);
            }
        }

        public static Predicate<FileSystemInfo>? GetFilterByFlag(string flag, string stringForFiltering)
        {
            Predicate<FileSystemInfo>? predicate;
            switch (flag)
            {
                case "-C":
                    predicate = item => item.Name.Contains(stringForFiltering);
                    break;
                case "-E":
                    predicate = item => item.Name.EndsWith(stringForFiltering);
                    break;
                case "-S":
                    predicate = item => item.Name.StartsWith(stringForFiltering);
                    break;
                default:
                    predicate = null;
                    break;
            }

            return predicate;
        }
    }
}