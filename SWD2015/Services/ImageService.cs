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
        public Image GetImageByID(int imageID)
        {
            return _imageRepository.Get(i => i.ID == imageID);
        }
    }
}