using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingStockMovimentation.Domain.Entitys;

namespace TrainingStockMovimentation.Domain.Interfaces
{
    public interface IContaBCRepository
    {
        List<ContaBC> GetAll();

        void CreateContaBC(ContaBC conta);

        void DeleterContaBC(long id);

        void UpdateContaBC(ContaBC conta);

        ContaBC GetConta(long id);
    }
}
