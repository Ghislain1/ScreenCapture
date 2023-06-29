// <copyright company="Ghislain One Inc.">
//  Copyright (c) GhislainOne
//  This computer program includes confidential, proprietary
//  information and is a trade secret of GhislainOne. All use,
//  disclosure, or reproduction is prohibited unless authorized in
//  writing by an officer of Ghis. All Rights Reserved.
// </copyright>

namespace ScreenCapture.ViewModels
{
    using Figma.ViewModels;
    using ScreenCapture.Models;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class DeviceConfigurationVM : ViewModelBase
    {
        ushort deviceId = 1;
        private DeviceConfiguration deviceModel;
        private ObservableCollection<VirtualProbeConfigurationVM> items = new ObservableCollection<VirtualProbeConfigurationVM>();

        private IDictionary<ushort, VirtualProbeConfigurationVM?> vpDic = new Dictionary<ushort, VirtualProbeConfigurationVM>();
        public ObservableCollection<VirtualProbeConfigurationVM> Items
        {
            get => this.items;
            set => this.SetProperty(ref this.items, value);
        }

        public DeviceConfigurationVM()
        {    // ALO
            this.deviceModel = new DeviceConfiguration(this.deviceId);
            this.SetUpDict();

        
            foreach (var item in this.deviceModel.VirtualProbeConfigurationCollection)
            {
                this.Items.Add(new VirtualProbeConfigurationVM(item));
            }
          
         
        }

        private void SetUpDict()
        {
            for (ushort i = 0; i < 8; i++)
            {
                for (ushort j = 0; j < 32; j++)
                {
                    var itemIdA = VirtualProbeOps.CalculateVirtualProbeId(i, j, 0);
                    var itemIdB = VirtualProbeOps.CalculateVirtualProbeId(i, j, 1);

                    this.vpDic.Add(itemIdA, null);
                    this.vpDic.Add(itemIdB, null);
                }
            }
            foreach (var item in this.deviceModel.VirtualProbeConfigurationCollection)
            {
                if (this.vpDic.ContainsKey(item.OriginId.VirtualProbeId))
                {
                    this.vpDic[item.OriginId.VirtualProbeId] = new VirtualProbeConfigurationVM(item);
                }
            }
        }
    }
}
