using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoReader.Module.FFProbeModule.DTO
{
    public class FFProbeFormatOutputTObject
    {
        public Format format { get; set; }
        public class Format
        {
            public string filename { get; set; }
            public int nb_streams { get; set; }
            public int nb_programs { get; set; }
            public string format_name { get; set; }
            public string format_long_name { get; set; }
            public string start_time { get; set; }
            public string end_time { get; set; }
            public string duration { get; set; }
            public string size { get; set; }
            public string bit_rate { get; set; }
            public int probe_score { get; set; }
            public Tags tags { get; set; }
        }
        public class Tags
        {
            public string major_brand { get; set; }
            public string minor_version { get; set; }
            public string compatible_brands { get; set; }
            public DateTime creation_time { get; set; }
        }

        public static FFProbeFormatOutputTObject FromJSON(string json)
        {
            FFProbeFormatOutputTObject data = JsonConvert.DeserializeObject<FFProbeFormatOutputTObject>(json);
            return data;
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
