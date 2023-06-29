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

    public class VirtualProbeConfiguration
    {
        public ushort DeviceId { get; }
        public OriginId OriginId { get; }
        public string Name { get; }
        public VpConfigurationAssignment ConfigurationAssignment { get; set; }= new VpConfigurationAssignment();
        public VirtualProbeConfiguration(ushort deviceId, ushort virtualProbeId)
        {
            this.DeviceId = deviceId;
            this.Name = $"D{deviceId} VP{virtualProbeId}";
            this.OriginId = new OriginId(deviceId, virtualProbeId);
        }

        internal void UpdateParameters()
        {
            this.OriginId.VirtualProbeId = VirtualProbeOps.CalculateVirtualProbeId(this.ConfigurationAssignment);
        }
    }
}
