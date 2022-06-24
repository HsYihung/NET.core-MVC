using System.Collections.Generic;

namespace Kendo.Mvc.Examples.Models
{
    public interface IDetailProductService
    {
        IEnumerable<DetailProductViewModel> Read();
        void Create(DetailProductViewModel product);
        void Update(DetailProductViewModel product);
        void Destroy(DetailProductViewModel product);
    }
}