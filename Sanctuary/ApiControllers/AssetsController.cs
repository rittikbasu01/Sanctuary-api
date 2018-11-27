using System.Net;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Threading.Tasks;
using IBusinessLayer;
using Sanctuary.Entities;

namespace Sanctuary.ApiControllers
{
    /// <summary>
    /// asset api controller
    /// </summary>
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("Assets")]
    public class AssetsController : ApiController
    {
        /// <summary>
        /// asset manager
        /// </summary>
        private readonly IAssetsManager AssetsManager;

        /// <summary>
        /// constructor for the asset controller
        /// </summary>
        /// <param name="assetsManager"></param>
        public AssetsController(IAssetsManager assetsManager)
        {
            this.AssetsManager = assetsManager;
        }

        /// <summary>
        ///  get asset by id
        /// </summary>
        /// <param name="assetid"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("get")]
        public Assets GetAssets(int assetid)    //need to do changes not neede right now
        {
            return this.AssetsManager.GetAssets(assetid);
        }

        /// <summary>
        /// post new asset
        /// </summary>
        /// <param name="assets"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("create")]
        public IHttpActionResult CreateAssets(Assets assets)    //need to do changes not neede right now
        {
            this.AssetsManager.CreateAssets(assets);
            return StatusCode(HttpStatusCode.NoContent);
        }

        /// <summary>
        /// update asset
        /// </summary>
        /// <param name="asset"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("Update")]
        public async Task<OperationResult> UpdatetAssets(Assets asset)
        {
            if (!ModelState.IsValid)
            {
                return new OperationResult()
                {
                    Status = false,
                    StatusCode = HttpStatusCode.BadRequest,
                    Message = "Bad Request",
                    Result = ModelState
                };
            }
            return await this.AssetsManager.UpdateAssets(asset);
        }

        /// <summary>
        ///  Delete asset by id
        /// </summary>
        /// <param name="assets"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("Delete")]
        public async Task<OperationResult> Delete(Assets assets)
        {
            string roomType = assets.RoomType;
            int locationId = assets.LocationId;
            return await this.AssetsManager.DeleteAssets(roomType, locationId);
        }

        /// <summary>
        /// get location for assets drop down
        /// </summary>
        /// <param name="countryName"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("LocationForAssets")]
        public async Task<OperationResult> getLocationNamesAssets(string countryName)
        {
            if (countryName != null)
                return await AssetsManager.GetLocationNamesAssets(countryName);

            return new OperationResult()
            {
                Status = false,
                StatusCode = HttpStatusCode.BadRequest,
                Message = "Bad Request",
                Result = ""
            };
        }


        /// <summary>
        ///  get all assets details
        /// </summary>
        /// <param name="assetid"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("getAllAssets")]
        public async Task<OperationResult> GetAllAssets()    
        {
            return await this.AssetsManager.GetAllAssets();
        }
    }
}

