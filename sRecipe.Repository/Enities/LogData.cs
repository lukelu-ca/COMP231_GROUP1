using sRecipe.Repository.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sRecipe.Repository.Entities
{
    public class LogData
    {
        public int LogDataId { get; set; }
        public string EmailAddress { get; set; }
        public string Host { get; set; }
        public string ContentType { get; set; }
        public string Accept { get; set; }
        [DefaultDateTimeValue("Now")]
        public DateTime? TimeStamp { get; set; }
        public bool Success { get; set; }
    }
}
