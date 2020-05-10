using CRMDESKTOPUI.Library.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRMDESKTOPUI.Library.Api
{
    public interface IProductEndpoint
    {
        Task<List<ProductModel>> GetAll();
    }
}