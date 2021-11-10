namespace ProductService.API.Application.CommonRequestModels
{
    public class ProductImageRequest
    {
        /// <summary>
        /// Name image
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Folder file Id image
        /// </summary>
        public string FileId { get; set; }

        /// <summary>
        /// Description image
        /// </summary>
        public string Description { get; set; }
    }
}
