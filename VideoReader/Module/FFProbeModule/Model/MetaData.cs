using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoReader.Module.FFProbeModule.Model
{
    public class MetaData
    {
        public DateTime Duration;
        public DateTime CreatedAt;
        public DateTime EndAt;

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
