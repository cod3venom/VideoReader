using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoReader.Adapter.Shell;
using VideoReader.Module.FFProbeModule;

namespace VideoReader
{
    public class AbstractFacade
    {
        public FFProbe FFProbe;
        protected readonly ShellAdapter _shellAdapter;
        public AbstractFacade() 
        { 
            this._shellAdapter = new ShellAdapter();
            this.FFProbe = new FFProbe(this._shellAdapter);
        }
    }
}
