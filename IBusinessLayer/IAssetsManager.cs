using System.Threading.Tasks;
using Sanctuary.Entities;

namespace IBusinessLayer
{
    /// <summary>
    /// asset manager interface
    /// </summary>
    public interface IAssetsManager
    {
        /// <summary>
        /// create a new asset
        /// </summary>
        /// <param name="assets"></param>
        void CreateAssets(Assets assets);

        /// <summary>
        /// get asset by asset_id
        /// </summary>
        /// <param name="assetid"></param>
        /// <returns></returns>
        Assets GetAssets(int assetid);

        /// <summary>
        /// update asset
        /// </summary>
        /// <param name="asset"></param>
        /// <returns></returns>
        Task<OperationResult> UpdateAssets(Assets asset);

        /// <summary>
        /// delete a asset
        /// </summary>
        /// <param name="roomtype"></param>
        /// <param name="locationid"></param>
        /// <returns></returns>
        Task<OperationResult> DeleteAssets(string roomType, int locationId);

        /// <summary>
        /// Get location name for corresponding country name
        /// </summary>
        /// <param name="countryName"></param>
        /// <returns></returns>
        Task<OperationResult> GetLocationNamesAssets(string countryName);

        /// <summary>
        /// Get all assets details
        /// </summary>
        /// <returns></returns>
        Task<OperationResult> GetAllAssets();
    }
}

