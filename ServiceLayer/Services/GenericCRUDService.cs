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
        public void AddNewEntryGeneric<T>(T entry) where T : class
        {
            using(VaultContext context = new VaultContext())
            {
                context.Add(entry);
                context.SaveChanges();
            }
        }

        public void DeleteEntryGeneric<T>(T entry) where T : class
        {
            using (VaultContext context = new VaultContext())
            {
                context.Remove(entry);
                context.SaveChanges();
            }
        }

        public void UpdateEntryGeneric<T>(T entry) where T : class
        {
            using (VaultContext context = new VaultContext())
            {
                context.Update(entry);
                context.SaveChanges();
            }
        }
    }
}
