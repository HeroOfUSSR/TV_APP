using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TV_APP_Context.Models
{
    public class Videos
    {
        [Key]
        public int ID_Video { get; set; }

        public byte[]? Source_Video { get; set; }
    }
}
