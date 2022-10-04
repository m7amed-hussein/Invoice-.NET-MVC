namespace InvoiceProj.Repositories
{
    public interface IInvoiceRepository<TEntity>
    {
        IList<TEntity> list();
        TEntity find(Guid id);
        void add(TEntity entity);
        void update(Guid id, TEntity entity);
        void delete(Guid id);
        List<TEntity> search(string term);
    }
}