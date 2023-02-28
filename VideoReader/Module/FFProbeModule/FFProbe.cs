using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoReader.Adapter.Shell;
using VideoReader.Module.FFProbeModule.DTO;
using VideoReader.Module.FFProbeModule.Model;

namespace VideoReader.Module.FFProbeModule
{
    public class FFProbe
    {
        private readonly ShellAdapter _shellAdapter;
        public FFProbe(ShellAdapter shellAdapter)
        {
            this._shellAdapter = shellAdapter;
        }

        public MetaData GetMetaData(string pathToVideo)
        {
            string output = this._shellAdapter.Execute("ffprobe.exe", string.Format(" -v quiet -show_format -print_format json {0}", pathToVideo));
            FFProbeFormatOutputTObject obj = FFProbeFormatOutputTObject.FromJSON(output);

            double duration;
            double.TryParse(obj.format.duration, out duration);

           
            MetaData meta = new MetaData();
            meta.CreatedAt = Convert.ToDateTime(obj.format.tags.creation_time);
            meta.Duration = meta.CreatedAt.AddSeconds(duration);
            meta.EndAt = meta.CreatedAt.Add(meta.Duration.TimeOfDay);

            return meta;
        }
    }
}
