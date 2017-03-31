using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace sRecipe.WebUI.Models
{
    public class RecipePictureViewModel
    {
        public int Id { get; set; }
        public byte[] Data { get; set; }
        public string MimeType { get; set; }
        public int UserId { get; set; }
        public DateTime? Uploaded_Time { get; set; }
        public string Description { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int Size { get; set; }
        public string FileName { get; set; }
        public int RecipeId { get; set; }
    }
}