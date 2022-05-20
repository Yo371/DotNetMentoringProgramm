namespace LibraryClass.Repositories
{
    public interface ILibraryRepository<T>
    {
        List<T> GetAll();

        void Update(List<T> list);
    }
}
