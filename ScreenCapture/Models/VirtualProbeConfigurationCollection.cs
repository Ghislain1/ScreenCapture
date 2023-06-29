// <copyright company="Ghislain One Inc.">
//  Copyright (c) GhislainOne
//  This computer program includes confidential, proprietary
//  information and is a trade secret of GhislainOne. All use,
//  disclosure, or reproduction is prohibited unless authorized in
//  writing by an officer of Ghis. All Rights Reserved.
// </copyright>

namespace ScreenCapture.Models
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Documents;

    public class VirtualProbeConfigurationCollection : IEnumerable<VirtualProbeConfiguration>
    {
        public ushort DeviceId { get;  }
        List<VirtualProbeConfiguration> vpList = new List<VirtualProbeConfiguration>();
        public IReadOnlyCollection<VirtualProbeConfiguration> VirtualProbeConfigurations
        {
            get => this.vpList.AsReadOnly(); 
            set => this.vpList = value.ToList();
        } 
        public VirtualProbeConfigurationCollection(ushort deviceId)
        {
            this.DeviceId = deviceId;        
        }

        public IEnumerator<VirtualProbeConfiguration> GetEnumerator()
        {
            return  this.vpList.GetEnumerator();
        }
        
        public  void Add (VirtualProbeConfiguration vp)
        {
            this.vpList.Add(vp);
        }

        public bool Remove(VirtualProbeConfiguration vp)
        {
           return this.vpList.Remove(vp);
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
        
    }
}
