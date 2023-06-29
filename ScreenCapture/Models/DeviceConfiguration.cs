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
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class DeviceConfiguration
    {
        public ushort DeviceId { get;  }
   
        public DeviceConfiguration(ushort deviceId)
        {
            this.DeviceId = deviceId;
            this.VirtualProbeConfigurationCollection = new VirtualProbeConfigurationCollection(this.DeviceId);

            // Just for demo
            var ves1 = VirtualProbeOps.CalculateVirtualProbeId(1, 1, 0);
            var ves2 = VirtualProbeOps.CalculateVirtualProbeId(1, 1, 1);
            this.VirtualProbeConfigurationCollection.Add( new VirtualProbeConfiguration(this.DeviceId, ves1));
            this.VirtualProbeConfigurationCollection.Add(new VirtualProbeConfiguration(this.DeviceId, ves2));
        }

        public VirtualProbeConfigurationCollection VirtualProbeConfigurationCollection { get; set; } 
    }
}
