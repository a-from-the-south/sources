using System;
using SlimDX;
using SlimDX.Direct3D9;

namespace ns6
{
	// Token: 0x020000AC RID: 172
	internal sealed class Class74
	{
		// Token: 0x060006C1 RID: 1729 RVA: 0x00066A64 File Offset: 0x00064C64
		public static Direct3D smethod_0()
		{
			return new Direct3D();
		}

		// Token: 0x060006C2 RID: 1730 RVA: 0x00066A7C File Offset: 0x00064C7C
		public static Device smethod_1(Direct3D direct3D_0, PresentParameters presentParameters_0, IntPtr intptr_0, out bool bool_0)
		{
			bool_0 = false;
			Configuration.EnableObjectTracking = true;
			Configuration.DetectDoubleDispose = false;
			Configuration.EnableObjectTracking = false;
			Configuration.DetectDoubleDispose = false;
			Configuration.AddResultWatch(ResultCode.DeviceLost, ResultWatchFlags.AlwaysIgnore);
			Configuration.AddResultWatch(ResultCode.WasStillDrawing, ResultWatchFlags.AlwaysIgnore);
			DeviceType deviceType = DeviceType.Hardware;
			int adapter = direct3D_0.Adapters.DefaultAdapter.Adapter;
			CreateFlags createFlags = CreateFlags.SoftwareVertexProcessing;
			Capabilities deviceCaps = direct3D_0.GetDeviceCaps(adapter, DeviceType.Hardware);
			if ((deviceCaps.DeviceCaps & DeviceCaps.HWTransformAndLight) != (DeviceCaps)0)
			{
				createFlags = CreateFlags.HardwareVertexProcessing;
			}
			if ((deviceCaps.FVFCaps & VertexFormatCaps.PointSize) != (VertexFormatCaps)0)
			{
				bool_0 = true;
			}
			if ((deviceCaps.DeviceCaps & DeviceCaps.PureDevice) != (DeviceCaps)0)
			{
				createFlags |= CreateFlags.PureDevice;
			}
			createFlags |= CreateFlags.Multithreaded;
			if (direct3D_0.CheckDeviceMultisampleType(adapter, deviceType, Format.D16, true, MultisampleType.FourSamples))
			{
				presentParameters_0.MultisampleQuality = 0;
				presentParameters_0.Multisample = MultisampleType.FourSamples;
			}
			else if (direct3D_0.CheckDeviceMultisampleType(adapter, deviceType, Format.D16, true, MultisampleType.TwoSamples))
			{
				presentParameters_0.MultisampleQuality = 0;
				presentParameters_0.Multisample = MultisampleType.TwoSamples;
			}
			presentParameters_0.Windowed = true;
			presentParameters_0.SwapEffect = SwapEffect.Discard;
			presentParameters_0.EnableAutoDepthStencil = true;
			presentParameters_0.AutoDepthStencilFormat = Format.D16;
			presentParameters_0.PresentationInterval = PresentInterval.Default;
			presentParameters_0.BackBufferHeight = 1024;
			presentParameters_0.BackBufferWidth = 1024;
			return new Device(direct3D_0, 0, DeviceType.Hardware, intptr_0, createFlags, new PresentParameters[]
			{
				presentParameters_0
			});
		}
	}
}
