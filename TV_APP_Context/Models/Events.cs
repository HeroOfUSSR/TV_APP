using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TV_APP_Context.Models
{
    public class Events
    {
        [Key]
        public int Id_Event { get; set; }

        public string Name_Event { get; set; } = string.Empty;

        public string Date_Event { get; set; } = string.Empty;

        public byte[]? Picture_Event { get; set; }
    }
}
