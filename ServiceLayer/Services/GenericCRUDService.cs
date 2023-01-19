using Datalayer;
using ServiceLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services
{
    public class GenericCRUDService : IGenericCRUDService
    {
        public readonly VaultContext _vaultContext;
        public GenericCRUDService(VaultContext vaultContext)
        {
            _vaultContext = vaultContext;
        }
        public void AddNewEntryGeneric<T>(T entry) where T : class
        {
            using(VaultContext context = _vaultContext)
            {
                context.Add(entry);
                context.SaveChanges();
            }
        }

        public void DeleteEntryGeneric<T>(T entry) where T : class
        {
            using (VaultContext context = _vaultContext)
            {
                context.Remove(entry);
                context.SaveChanges();
            }
        }

        public void UpdateEntryGeneric<T>(T entry) where T : class
        {
            using (VaultContext context = _vaultContext)
            {
                context.Update(entry);
                context.SaveChanges();
            }
        }
    }
}
