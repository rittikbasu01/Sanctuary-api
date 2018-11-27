using System.Threading.Tasks;
using IBusinessLayer;
using Sanctuary.DataAccessLayer.IServiceRepositry;
using Sanctuary.Entities;

namespace BusinessLayer
{
    /// <summary>
    /// asset manager
    /// </summary>
    public class AssetsManager : IAssetsManager
    {
        private readonly IAssetsService AssetsService;

        public AssetsManager(IAssetsService assetsService)
        {
            this.AssetsService = assetsService;
        }
        /// <summary>
        /// Create method for asset
        /// </summary>
        /// <param name="assets"></param>
        public void CreateAssets(Assets assets)
        {
            this.AssetsService.CreateAssets(assets);
        }
        /// <summary>
        /// get method for finding details as per id
        /// </summary>
        /// <param name="assetid"></param>
        /// <returns></returns>

        public Assets GetAssets(int assetid)
        {
            return this.AssetsService.GetAssets(assetid);
        }
        /// <summary>
        /// Update database according to id and it will update roomprice
        /// </summary>
        /// <param name="assetid"></param>
        /// <param name="roomprice"></param>
        public async Task<OperationResult> UpdateAssets(Assets asset)
        {
           return await this.AssetsService.UpdateAssets(asset);
        }

        /// <summary>
        /// delete a asset
        /// </summary>
        /// <param name="assetsid"></param>
        public async Task<OperationResult> DeleteAssets(string roomType, int locationId)
        {
           return await this.AssetsService.DeleteAssets(roomType, locationId);
        }

        /// <summary>
        /// get asset details by country name
        /// </summary>
        /// <param name="assetsid"></param>
        public async Task<OperationResult> GetLocationNamesAssets(string countryName)
        {
            return await this.AssetsService.GetLocationNamesAssets(countryName);
        }

        /// <summary>
        /// get all assets details
        /// </summary>
        /// <param name="assetsid"></param>
        public async Task<OperationResult> GetAllAssets()
        {
            return await this.AssetsService.GetAllAssets();
        }

    }

}
