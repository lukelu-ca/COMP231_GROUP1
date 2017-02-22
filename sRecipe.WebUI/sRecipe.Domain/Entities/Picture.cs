using sRecipe.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sRecipe.Domain.Entities
{
    public class Picture
    {
        [Key]
        public int Id { get; set; }
        public byte[] Data { get; set; }
        public virtual User User { get; set; }

        [DefaultDateTimeValue("Now")]
        public DateTime? Uploaded_Time { get; set; }
        public string Description { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int Size { get; set; }
        public string FileName { get; set; }

    }
}
