using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sanctuary.Entities;

namespace Sanctuary.DataAccessLayer.IServiceRepositry
{
    public interface IAssetsService
    {
        void CreateAssets(Assets assets);
        Assets GetAssets(int assetid);
        Task<OperationResult> UpdateAssets(Assets asset);
        Task<OperationResult> DeleteAssets(string roomType, int locationId);

        Task<OperationResult> GetLocationNamesAssets(string countryName);

        Task<OperationResult> GetAllAssets();
    }
}

    