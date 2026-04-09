using Azure.Core;
using Microsoft.EntityFrameworkCore;
using TrainingStockMovimentation.Domain.Entitys;
using TrainingStockMovimentation.Domain.Interfaces;
using TrainingStockMovimentation.Infra.Database.Context;

namespace TrainingStockMovimentation.Infra.Repository
{
    public class SupplierRepository : BaseRepository, ISupplierRepository
    {
        private readonly AppDbContext _context;

        public SupplierRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public void AddSupplier(Supplier supplier)
        {
            _context.Suppliers.Add(supplier);
            _context.SaveChanges();
        }

        public void DeleteSupplier(long id)
        {
            var supplirRemove = _context.Suppliers.Where(x => x.Id == id).FirstOrDefault();

            if (supplirRemove is null)
                throw new Exception("Falha ao deletar");

            _context.Suppliers.Remove(supplirRemove);
            _context.SaveChanges();

        }

        public List<Supplier> GetAllSuppliers()
        {
            var suppliers =  _context.Suppliers.ToList();

            return suppliers;
        }

        public Supplier GetSupplier(long id)
        {
            var supplier = _context.Suppliers.Include(x => x.Products).FirstOrDefault(x => x.Id == id);

            if (supplier is null)
                return new Supplier();

            return supplier;
        }

        public void UpdateSupplier(long id, Supplier supplier)
        {
            var supplierUpdate = _context.Suppliers.FirstOrDefault(x => x.Id == id);

            if (supplierUpdate is null)
                throw new Exception("Falha ao atualizar");

            supplierUpdate.Name = supplier.Name;
            supplierUpdate.CNPJ = supplierUpdate.CNPJ;
            supplierUpdate.ProductCategory = supplierUpdate.ProductCategory;

            _context.SaveChanges();
        }


        public bool ValidaVinculoProduto(long id)
        {
            var SupplierProduct = _context.Suppliers.Include(x => x.Products).FirstOrDefault(x => x.Id == id);

            if (SupplierProduct.Products.Count() >= 1)
                return false;

            return true;
        }
    }
}
