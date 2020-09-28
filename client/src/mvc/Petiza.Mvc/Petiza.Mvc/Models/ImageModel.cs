using Microsoft.AspNetCore.Http;

namespace Petiza.Mvc.Models
{
    public class ImageModel
    {
        public int ImageId { get; set; }

        public string Title { get; set; }

        public string ImageName { get; set; }

        public IFormFile ImageFile { get; set; }
    }
}