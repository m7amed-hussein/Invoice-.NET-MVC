namespace InvoiceProj.Repositories
{
    public interface IInvoiceRepository<TEntity>
    {
        IList<TEntity> list();
        TEntity find(int id);
        void add(TEntity entity);
        void update(int id, TEntity entity);
        void delete(int id);
        List<TEntity> search(string term);
    }
}