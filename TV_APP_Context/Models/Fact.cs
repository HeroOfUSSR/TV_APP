using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TV_APP_Context.Models
{
    public partial class Fact
    {
        public int IdFact { get; set; }

        public string DescFact { get; set; } = string.Empty;

        public string TitleFact { get; set; } = string.Empty;

        public byte[]? PictureFact { get; set; }
    }
}
