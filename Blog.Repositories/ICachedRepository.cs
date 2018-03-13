namespace Blog.Repositories
{
    public interface ICachedRepository
    {
        void InvalidateCache();
    }
}
