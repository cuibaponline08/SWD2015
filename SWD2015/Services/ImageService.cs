using SWD2015.Infrastructure;
using SWD2015.Models;
using SWD2015.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SWD2015.Services
{
    public class ImageService : IImageService
    {
        private IRepository<Image> _imageRepository = new ImageRepository();

        public IQueryable GetAllBanners()
        {
            return _imageRepository.GetMany(i => i.AlbumID == 2).Select(i => new { i.ImageURL });
        }
    }
}