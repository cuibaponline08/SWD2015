using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using SWD2015.Models;
using SWD2015.Services;

namespace SWD2015.Controllers
{
    public class ImageController : ApiController
    {
        private IImageService _imageService = new ImageService();

        // GET api/Image/Banner/GetAllBanners
        [Route("api/Image/Banner/GetAllBanners")]
        public IQueryable GetAllBanners()
        {
            return _imageService.GetAllBanners();
        }
    }
}