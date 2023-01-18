using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Interface
{
    public interface IGenericCRUDService
    {
        public void AddNewEntryGeneric<T>(T Entry) where T : class;
        public void UpdateEntryGeneric<T>(T entry) where T : class;
        public void DeleteEntryGeneric<T>(T entry) where T : class;
    }
}
