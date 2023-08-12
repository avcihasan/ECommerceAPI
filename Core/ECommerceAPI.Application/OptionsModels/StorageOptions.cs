using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.OptionsModels
{
    public class StorageOptions
    {
        public const string Storage = "Storage";
        public string BaseStorageUrl { get; set; }
        public string Azure { get; set; }
        public string AWS { get; set; }
        public string Google { get; set; }
    }
}
