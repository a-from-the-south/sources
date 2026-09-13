using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using ns10;
using ns16;
using ns17;
using ns8;
using SlimDX;
using SlimDX.Direct3D9;

namespace ns6
{
	// Token: 0x02000124 RID: 292
	internal sealed class Class140
	{
		// Token: 0x1700029F RID: 671
		// (get) Token: 0x06000D2C RID: 3372 RVA: 0x000A7B18 File Offset: 0x000A5D18
		// (set) Token: 0x06000D2D RID: 3373 RVA: 0x00007474 File Offset: 0x00005674
		public Class140.Enum20 CurrentRenderMode { get; set; }

		// Token: 0x170002A0 RID: 672
		// (get) Token: 0x06000D2E RID: 3374 RVA: 0x000A7B30 File Offset: 0x000A5D30
		// (set) Token: 0x06000D2F RID: 3375 RVA: 0x0000747F File Offset: 0x0000567F
		public bool IsRenderingToSurface { get; set; }

		// Token: 0x170002A1 RID: 673
		// (get) Token: 0x06000D30 RID: 3376 RVA: 0x000A7B48 File Offset: 0x000A5D48
		// (set) Token: 0x06000D31 RID: 3377 RVA: 0x0000748A File Offset: 0x0000568A
		public bool Inited { get; private set; }

		// Token: 0x170002A2 RID: 674
		// (get) Token: 0x06000D32 RID: 3378 RVA: 0x000A7B60 File Offset: 0x000A5D60
		public Device Device
		{
			get
			{
				return this.device_0;
			}
		}

		// Token: 0x170002A3 RID: 675
		// (get) Token: 0x06000D33 RID: 3379 RVA: 0x000A7B78 File Offset: 0x000A5D78
		public int AdapterOrdinal
		{
			get
			{
				return this.int_0;
			}
		}

		// Token: 0x170002A4 RID: 676
		// (get) Token: 0x06000D34 RID: 3380 RVA: 0x000A7B90 File Offset: 0x000A5D90
		public Effect Effect
		{
			get
			{
				return this.effect_0;
			}
		}

		// Token: 0x170002A5 RID: 677
		// (get) Token: 0x06000D35 RID: 3381 RVA: 0x000A7BA8 File Offset: 0x000A5DA8
		public Surface DefaultRenderTarget
		{
			get
			{
				return this.surface_0;
			}
		}

		// Token: 0x170002A6 RID: 678
		// (get) Token: 0x06000D36 RID: 3382 RVA: 0x000A7BC0 File Offset: 0x000A5DC0
		public Surface DefaultDepthStencil
		{
			get
			{
				return this.surface_1;
			}
		}

		// Token: 0x1400002D RID: 45
		// (add) Token: 0x06000D37 RID: 3383 RVA: 0x000A7BD8 File Offset: 0x000A5DD8
		// (remove) Token: 0x06000D38 RID: 3384 RVA: 0x000A7C10 File Offset: 0x000A5E10
		public event EventHandler<EventArgs3> OnDeviceReset
		{
			add
			{
				EventHandler<EventArgs3> eventHandler = this.eventHandler_0;
				EventHandler<EventArgs3> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler<EventArgs3> value2 = (EventHandler<EventArgs3>)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler<EventArgs3>>(ref this.eventHandler_0, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
			remove
			{
				EventHandler<EventArgs3> eventHandler = this.eventHandler_0;
				EventHandler<EventArgs3> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler<EventArgs3> value2 = (EventHandler<EventArgs3>)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler<EventArgs3>>(ref this.eventHandler_0, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
		}

		// Token: 0x1400002E RID: 46
		// (add) Token: 0x06000D39 RID: 3385 RVA: 0x000A7C48 File Offset: 0x000A5E48
		// (remove) Token: 0x06000D3A RID: 3386 RVA: 0x000A7C80 File Offset: 0x000A5E80
		public event EventHandler<EventArgs3> OnDeviceReseted
		{
			add
			{
				EventHandler<EventArgs3> eventHandler = this.eventHandler_1;
				EventHandler<EventArgs3> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler<EventArgs3> value2 = (EventHandler<EventArgs3>)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler<EventArgs3>>(ref this.eventHandler_1, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
			remove
			{
				EventHandler<EventArgs3> eventHandler = this.eventHandler_1;
				EventHandler<EventArgs3> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler<EventArgs3> value2 = (EventHandler<EventArgs3>)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler<EventArgs3>>(ref this.eventHandler_1, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
		}

		// Token: 0x170002A7 RID: 679
		// (get) Token: 0x06000D3B RID: 3387 RVA: 0x000A7CB8 File Offset: 0x000A5EB8
		public VertexDeclaration VertexDeclaration
		{
			get
			{
				return this.vertexDeclaration_0;
			}
		}

		// Token: 0x170002A8 RID: 680
		// (get) Token: 0x06000D3C RID: 3388 RVA: 0x000A7CD0 File Offset: 0x000A5ED0
		public Capabilities DeviceCaps
		{
			get
			{
				return this.direct3D_0.GetDeviceCaps(this.int_0, DeviceType.Hardware);
			}
		}

		// Token: 0x170002A9 RID: 681
		// (get) Token: 0x06000D3D RID: 3389 RVA: 0x000A7CF4 File Offset: 0x000A5EF4
		public static int InitializeError
		{
			get
			{
				return Class140.int_1;
			}
		}

		// Token: 0x06000D3E RID: 3390 RVA: 0x000A7D0C File Offset: 0x000A5F0C
		public Class140()
		{
			this.dictionary_0 = new Dictionary<RenderState, object>();
			Class140.int_1 = this.method_3();
			if (Class140.int_1 == 0)
			{
				this.Inited = true;
				this.method_4();
			}
			else
			{
				this.Inited = false;
			}
		}

		// Token: 0x06000D3F RID: 3391 RVA: 0x000A7D60 File Offset: 0x000A5F60
		public static Class140 smethod_0()
		{
			if (Class140.class140_0 == null || !Class140.class140_0.Inited)
			{
				Class140.class140_0 = new Class140();
			}
			Class140 result;
			if (!Class140.class140_0.Inited)
			{
				result = null;
			}
			else
			{
				result = Class140.class140_0;
			}
			return result;
		}

		// Token: 0x06000D40 RID: 3392 RVA: 0x000A7DA4 File Offset: 0x000A5FA4
		public bool method_0(Format format_0, Usage usage_0, ResourceType resourceType_0, Format format_1)
		{
			return this.direct3D_0.CheckDeviceFormat(this.int_0, DeviceType.Hardware, format_0, usage_0, resourceType_0, format_1);
		}

		// Token: 0x06000D41 RID: 3393 RVA: 0x000A7DCC File Offset: 0x000A5FCC
		public bool method_1()
		{
			if (this.bool_1)
			{
				Thread.Sleep(50);
				Result left = this.method_8();
				if (left != ResultCode.Success)
				{
					return false;
				}
			}
			this.bool_1 = false;
			this.device_0.BeginScene();
			return true;
		}

		// Token: 0x06000D42 RID: 3394 RVA: 0x000A7E18 File Offset: 0x000A6018
		public void method_2()
		{
			this.device_0.EndScene();
			Result left = this.device_0.Present();
			if (!(left == ResultCode.DeviceLost) && !(left == ResultCode.DeviceLost))
			{
				if (left == ResultCode.DeviceNotReset)
				{
					left = this.method_8();
				}
			}
			else if (this.method_8() == ResultCode.DeviceLost)
			{
				this.bool_1 = true;
			}
		}

		// Token: 0x06000D43 RID: 3395 RVA: 0x000A7E8C File Offset: 0x000A608C
		private int method_3()
		{
			int result;
			try
			{
				this.direct3D_0 = Class74.smethod_0();
				this.int_0 = this.direct3D_0.Adapters.DefaultAdapter.Adapter;
				this.presentParameters_0 = new PresentParameters();
				MeshEditor meshEditor = Class132.smethod_0();
				this.device_0 = Class74.smethod_1(this.direct3D_0, this.presentParameters_0, meshEditor.RenderPanel.Handle, out this.bool_0);
				result = 0;
			}
			catch (Exception ex)
			{
				if (ex is Direct3DX9NotFoundException)
				{
					result = -3;
				}
				else if (ex is Direct3D9NotFoundException)
				{
					result = -2;
				}
				else
				{
					MessageBox.Show(ex.ToString(), "Error");
					result = -1;
				}
			}
			return result;
		}

		// Token: 0x06000D44 RID: 3396 RVA: 0x000A7F44 File Offset: 0x000A6144
		private void method_4()
		{
			this.method_5();
			this.surface_0 = this.device_0.GetRenderTarget(0);
			this.surface_1 = this.device_0.DepthStencilSurface;
			this.vertexDeclaration_0 = new VertexDeclaration(this.device_0, Class112.Struct7.VertexElements);
			this.device_0.VertexDeclaration = this.vertexDeclaration_0;
			try
			{
				this.direct3D_0.GetDeviceCaps(this.int_0, DeviceType.Hardware);
			}
			catch (Exception ex)
			{
				MessageBox.Show(Class132.mainForm, "Could not create shadowmap texture.\n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
		}

		// Token: 0x06000D45 RID: 3397 RVA: 0x000A7FF0 File Offset: 0x000A61F0
		public void method_5()
		{
			string text = "";
			MemoryStream memoryStream = new MemoryStream(Class143.shaders_fxo);
			this.effect_0 = Effect.FromStream(this.device_0, memoryStream, null, null, null, ShaderFlags.None, null, out text);
			if (!string.IsNullOrEmpty(text))
			{
				MessageBox.Show("Could not effects\n\n" + text);
			}
			memoryStream.Dispose();
		}

		// Token: 0x06000D46 RID: 3398 RVA: 0x000A8048 File Offset: 0x000A6248
		protected void method_6(bool bool_4)
		{
			this.vertexDeclaration_0.Dispose();
			this.effect_0.Dispose();
			this.surface_0.Dispose();
			this.surface_1.Dispose();
			if (bool_4)
			{
				this.direct3D_0.Dispose();
				this.device_0.Dispose();
			}
		}

		// Token: 0x06000D47 RID: 3399 RVA: 0x00007495 File Offset: 0x00005695
		public void method_7()
		{
			this.method_6(true);
		}

		// Token: 0x06000D48 RID: 3400 RVA: 0x000A809C File Offset: 0x000A629C
		public Result method_8()
		{
			Console.WriteLine("Device reset!!!!!!");
			Result left = this.device_0.TestCooperativeLevel();
			Result result;
			if (left == ResultCode.DeviceLost)
			{
				result = ResultCode.DeviceLost;
			}
			else
			{
				this.vmethod_0(new EventArgs3(this.device_0));
				this.method_6(false);
				Panel renderPanel = Class132.smethod_0().RenderPanel;
				int num = (int)(Math.Ceiling((double)renderPanel.Width) - 0.0);
				int num2 = (int)(Math.Ceiling((double)renderPanel.Height) - 0.0);
				if (num < 1 && num2 < 1)
				{
					result = ResultCode.DeviceNotReset;
				}
				else
				{
					this.presentParameters_0.BackBufferWidth = num;
					this.presentParameters_0.BackBufferHeight = num2;
					Result result2 = this.device_0.Reset(new PresentParameters[]
					{
						this.presentParameters_0
					});
					if (result2 == ResultCode.Success)
					{
						this.dictionary_0.Clear();
						this.method_4();
						this.vmethod_1(new EventArgs3(this.device_0));
					}
					result = result2;
				}
			}
			return result;
		}

		// Token: 0x06000D49 RID: 3401 RVA: 0x000A81B0 File Offset: 0x000A63B0
		public void method_9(RenderState renderState_0, object object_0)
		{
			object objB = null;
			if (!this.dictionary_0.TryGetValue(renderState_0, out objB))
			{
				this.dictionary_0.Add(renderState_0, object_0);
			}
			else
			{
				this.dictionary_0[renderState_0] = object_0;
			}
			if (!object.Equals(object_0, objB))
			{
				if (object_0 is float)
				{
					this.Device.SetRenderState(renderState_0, (float)object_0);
				}
				else if (object_0 is bool)
				{
					this.Device.SetRenderState(renderState_0, (bool)object_0);
				}
				else if (object_0 is int)
				{
					this.Device.SetRenderState(renderState_0, (int)object_0);
				}
				else if (object_0 is Blend)
				{
					this.Device.SetRenderState<Blend>(renderState_0, (Blend)object_0);
				}
				else if (object_0 is Cull)
				{
					this.Device.SetRenderState<Cull>(renderState_0, (Cull)object_0);
				}
				else if (object_0 is FillMode)
				{
					this.Device.SetRenderState<FillMode>(renderState_0, (FillMode)object_0);
				}
				else if (object_0 is ColorWriteEnable)
				{
					this.Device.SetRenderState<ColorWriteEnable>(renderState_0, (ColorWriteEnable)object_0);
				}
				else if (object_0 is VertexBlend)
				{
					this.Device.SetRenderState<VertexBlend>(renderState_0, (VertexBlend)object_0);
				}
				else if (object_0 is int)
				{
					this.Device.SetRenderState(renderState_0, (int)object_0);
				}
				else
				{
					if (!(object_0 is Compare))
					{
						throw new Exception("Not setting " + renderState_0.ToString() + " unknown type");
					}
					this.Device.SetRenderState<Compare>(renderState_0, (Compare)object_0);
				}
			}
		}

		// Token: 0x06000D4A RID: 3402 RVA: 0x000074A0 File Offset: 0x000056A0
		public void method_10()
		{
			this.Device.VertexDeclaration = this.vertexDeclaration_0;
		}

		// Token: 0x06000D4B RID: 3403 RVA: 0x000074B5 File Offset: 0x000056B5
		public void method_11(Vector2 vector2_0, Vector2 vector2_1, Vector2 vector2_2)
		{
			this.method_24("diffuseUVSelector", vector2_0);
			this.method_24("specularUVSelector", vector2_1);
			this.method_24("normalMapUVSelector", vector2_2);
		}

		// Token: 0x06000D4C RID: 3404 RVA: 0x000074DD File Offset: 0x000056DD
		public void method_12(Vector4 vector4_0, Vector4 vector4_1)
		{
			this.method_22("g_PosScale", vector4_0);
			this.method_22("g_PosOffset", vector4_1);
		}

		// Token: 0x06000D4D RID: 3405 RVA: 0x000074F9 File Offset: 0x000056F9
		public void method_13(int int_2)
		{
			this.method_30("selectedBone", int_2);
		}

		// Token: 0x06000D4E RID: 3406 RVA: 0x00007509 File Offset: 0x00005709
		public void method_14(Texture texture_0)
		{
			this.method_21("g_txScene", texture_0);
		}

		// Token: 0x06000D4F RID: 3407 RVA: 0x00007519 File Offset: 0x00005719
		public void method_15(string string_0, Texture texture_0)
		{
			this.method_21(string_0, texture_0);
		}

		// Token: 0x06000D50 RID: 3408 RVA: 0x00007525 File Offset: 0x00005725
		public void method_16(Texture texture_0)
		{
			this.method_21("g_txDirtMap", texture_0);
		}

		// Token: 0x06000D51 RID: 3409 RVA: 0x00007535 File Offset: 0x00005735
		public void method_17(Texture texture_0)
		{
			this.method_21("g_txDropShadow", texture_0);
		}

		// Token: 0x06000D52 RID: 3410 RVA: 0x00007545 File Offset: 0x00005745
		public void method_18(Texture texture_0)
		{
			this.method_21("g_txDiffMap", texture_0);
		}

		// Token: 0x06000D53 RID: 3411 RVA: 0x00007555 File Offset: 0x00005755
		public void method_19(Texture texture_0)
		{
			this.method_21("g_txSpecMap", texture_0);
		}

		// Token: 0x06000D54 RID: 3412 RVA: 0x00007565 File Offset: 0x00005765
		public void method_20(Texture texture_0)
		{
			this.method_21("g_txNormalMap", texture_0);
		}

		// Token: 0x06000D55 RID: 3413 RVA: 0x00007575 File Offset: 0x00005775
		public void method_21(string string_0, Texture texture_0)
		{
			this.effect_0.SetTexture(string_0, texture_0);
		}

		// Token: 0x06000D56 RID: 3414 RVA: 0x0000758C File Offset: 0x0000578C
		public void method_22(string string_0, Vector4 vector4_0)
		{
			this.effect_0.SetValue<Vector4>(this.effect_0.GetParameter(null, string_0), vector4_0);
		}

		// Token: 0x06000D57 RID: 3415 RVA: 0x000075AA File Offset: 0x000057AA
		public void method_23(string string_0, Vector3 vector3_0)
		{
			this.effect_0.SetValue<Vector3>(this.effect_0.GetParameter(null, string_0), vector3_0);
		}

		// Token: 0x06000D58 RID: 3416 RVA: 0x000075C8 File Offset: 0x000057C8
		public void method_24(string string_0, Vector2 vector2_0)
		{
			this.effect_0.SetValue<Vector2>(this.effect_0.GetParameter(null, string_0), vector2_0);
		}

		// Token: 0x06000D59 RID: 3417 RVA: 0x000075E6 File Offset: 0x000057E6
		public void method_25(string string_0, Matrix matrix_0)
		{
			this.effect_0.SetValue<Matrix>(this.effect_0.GetParameter(null, string_0), matrix_0);
		}

		// Token: 0x06000D5A RID: 3418 RVA: 0x00007604 File Offset: 0x00005804
		public void method_26(string string_0, Matrix[] matrix_0)
		{
			if (!string_0.Equals("amPalette") || matrix_0.Length <= 60)
			{
				if (matrix_0.Length > 0)
				{
					this.effect_0.SetValue<Matrix>(this.effect_0.GetParameter(null, string_0), matrix_0);
				}
			}
		}

		// Token: 0x06000D5B RID: 3419 RVA: 0x0000763E File Offset: 0x0000583E
		public void method_27(string string_0, bool bool_4)
		{
			this.effect_0.SetValue<bool>(this.effect_0.GetParameter(null, string_0), bool_4);
		}

		// Token: 0x06000D5C RID: 3420 RVA: 0x0000765C File Offset: 0x0000585C
		public void method_28(string string_0, float float_0)
		{
			this.effect_0.SetValue<float>(this.effect_0.GetParameter(null, string_0), float_0);
		}

		// Token: 0x06000D5D RID: 3421 RVA: 0x0000767A File Offset: 0x0000587A
		public void method_29(string string_0, float[] float_0)
		{
			this.effect_0.SetValue<float>(this.effect_0.GetParameter(null, string_0), float_0);
		}

		// Token: 0x06000D5E RID: 3422 RVA: 0x00007698 File Offset: 0x00005898
		public void method_30(string string_0, int int_2)
		{
			this.effect_0.SetValue<int>(this.effect_0.GetParameter(null, string_0), int_2);
		}

		// Token: 0x06000D5F RID: 3423 RVA: 0x000076B6 File Offset: 0x000058B6
		public void method_31(string string_0, Color4 color4_0)
		{
			this.effect_0.SetValue<Color4>(this.effect_0.GetParameter(null, string_0), color4_0);
		}

		// Token: 0x06000D60 RID: 3424 RVA: 0x000A8350 File Offset: 0x000A6550
		public void method_32(Matrix matrix_0, Matrix matrix_1)
		{
			this.method_25("g_mWorldView", matrix_0 * matrix_1);
			this.method_25("g_mWorld", matrix_0);
			Matrix matrix_2 = matrix_0;
			matrix_2.Invert();
			this.method_25("g_mIWorld", matrix_2);
			Matrix matrix_3 = Matrix.Transpose(Matrix.Invert(matrix_0));
			this.method_25("WorldInverseTranspose", matrix_3);
			this.effect_0.CommitChanges();
		}

		// Token: 0x06000D61 RID: 3425 RVA: 0x000076D4 File Offset: 0x000058D4
		public void method_33(Matrix[] matrix_0)
		{
			this.method_26("amPalette", matrix_0);
		}

		// Token: 0x06000D62 RID: 3426 RVA: 0x000076E4 File Offset: 0x000058E4
		public void method_34(bool bool_4)
		{
			this.method_27("isSkinned", bool_4);
		}

		// Token: 0x06000D63 RID: 3427 RVA: 0x000A83B8 File Offset: 0x000A65B8
		public Result method_35()
		{
			return this.effect_0.CommitChanges();
		}

		// Token: 0x06000D64 RID: 3428 RVA: 0x000A83D4 File Offset: 0x000A65D4
		public int method_36()
		{
			return this.effect_0.Begin();
		}

		// Token: 0x06000D65 RID: 3429 RVA: 0x000076F4 File Offset: 0x000058F4
		public void method_37()
		{
			this.effect_0.End();
		}

		// Token: 0x06000D66 RID: 3430 RVA: 0x00007704 File Offset: 0x00005904
		public void method_38(int int_2)
		{
			this.effect_0.BeginPass(int_2);
		}

		// Token: 0x06000D67 RID: 3431 RVA: 0x00007715 File Offset: 0x00005915
		public void method_39()
		{
			this.effect_0.EndPass();
		}

		// Token: 0x06000D68 RID: 3432 RVA: 0x00007725 File Offset: 0x00005925
		public void method_40(string string_0)
		{
			this.effect_0.Technique = this.effect_0.GetTechnique(string_0);
		}

		// Token: 0x06000D69 RID: 3433 RVA: 0x000A83F0 File Offset: 0x000A65F0
		protected void vmethod_0(EventArgs3 eventArgs3_0)
		{
			EventHandler<EventArgs3> eventHandler = this.eventHandler_0;
			if (eventHandler != null)
			{
				eventHandler(this, eventArgs3_0);
			}
		}

		// Token: 0x06000D6A RID: 3434 RVA: 0x000A8414 File Offset: 0x000A6614
		protected void vmethod_1(EventArgs3 eventArgs3_0)
		{
			EventHandler<EventArgs3> eventHandler = this.eventHandler_1;
			if (eventHandler != null)
			{
				eventHandler(this, eventArgs3_0);
			}
		}

		// Token: 0x04000A0A RID: 2570
		private static Class140 class140_0;

		// Token: 0x04000A0B RID: 2571
		private Device device_0;

		// Token: 0x04000A0C RID: 2572
		private Direct3D direct3D_0;

		// Token: 0x04000A0D RID: 2573
		private int int_0;

		// Token: 0x04000A0E RID: 2574
		private PresentParameters presentParameters_0;

		// Token: 0x04000A0F RID: 2575
		public bool bool_0;

		// Token: 0x04000A10 RID: 2576
		private Effect effect_0;

		// Token: 0x04000A11 RID: 2577
		private Surface surface_0;

		// Token: 0x04000A12 RID: 2578
		private Surface surface_1;

		// Token: 0x04000A13 RID: 2579
		private Dictionary<RenderState, object> dictionary_0 = new Dictionary<RenderState, object>();

		// Token: 0x04000A14 RID: 2580
		private EventHandler<EventArgs3> eventHandler_0;

		// Token: 0x04000A15 RID: 2581
		private EventHandler<EventArgs3> eventHandler_1;

		// Token: 0x04000A16 RID: 2582
		private VertexDeclaration vertexDeclaration_0;

		// Token: 0x04000A17 RID: 2583
		private static int int_1 = 0;

		// Token: 0x04000A18 RID: 2584
		private bool bool_1;

		// Token: 0x04000A19 RID: 2585
		[CompilerGenerated]
		private Class140.Enum20 enum20_0;

		// Token: 0x04000A1A RID: 2586
		[CompilerGenerated]
		private bool bool_2;

		// Token: 0x04000A1B RID: 2587
		[CompilerGenerated]
		private bool bool_3;

		// Token: 0x02000125 RID: 293
		public enum Enum20
		{
			// Token: 0x04000A1D RID: 2589
			const_0 = 1,
			// Token: 0x04000A1E RID: 2590
			const_1
		}
	}
}
