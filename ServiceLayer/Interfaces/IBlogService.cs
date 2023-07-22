namespace ServiceLayer.Interfaces
{
    public interface IBlogService<TEntity>
    {
        //void EditBlogContent(int id, string newContent);
        ICollection<TEntity> SortByTitle();
        ICollection<TEntity> SortByPublished();
        ICollection<TEntity> SortByAuthorName();
        decimal GetBlogRating(int id);
    }
}
