//  ---------------------------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All rights reserved.
// 
//  The MIT License (MIT)
// 
//  Permission is hereby granted, free of charge, to any person obtaining a copy
//  of this software and associated documentation files (the "Software"), to deal
//  in the Software without restriction, including without limitation the rights
//  to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//  copies of the Software, and to permit persons to whom the Software is
//  furnished to do so, subject to the following conditions:
// 
//  The above copyright notice and this permission notice shall be included in
//  all copies or substantial portions of the Software.
// 
//  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//  OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
//  THE SOFTWARE.
//  ---------------------------------------------------------------------------------



namespace Composition.WindowsRuntimeHelpers;
using Windows.Win32.Foundation;
using Windows.Win32.Graphics.Gdi;
using Windows.Win32.System.WinRT.Graphics.Capture;
using System;
using Windows.Graphics.Capture;
using WinRT.Interop;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
public static class CaptureHelper
{
    static readonly Guid GraphicsCaptureItemGuid = new Guid("79C3F95B-31F7-4EC2-A464-632EF5D30760");

    public static void SetWindow(this GraphicsCapturePicker picker, HWND hwnd)
    {
        InitializeWithWindow.Initialize(picker, hwnd);
    }

    public static GraphicsCaptureItem CreateItemForWindow(HWND hwnd)
    {
        GraphicsCaptureItem item = null;
        unsafe
        {
            item = CreateItemForCallback((IGraphicsCaptureItemInterop interop, Guid* guid) =>
            {
                interop.CreateForWindow(hwnd, guid, out object raw);
                return raw;
            });
        }
        return item;
    }

    public static GraphicsCaptureItem CreateItemForMonitor(HMONITOR hmon)
    {
        GraphicsCaptureItem item = null;
        unsafe
        {
            item = CreateItemForCallback((IGraphicsCaptureItemInterop interop, Guid* guid) =>
            {
                interop.CreateForMonitor(hmon, guid, out object raw);
                return raw;
            });
        }
        return item;
    }

    private unsafe delegate object InteropCallback(IGraphicsCaptureItemInterop interop, Guid* guid);

    private static GraphicsCaptureItem CreateItemForCallback(InteropCallback callback)
    {
        var interop = GraphicsCaptureItem.As<IGraphicsCaptureItemInterop>();
        GraphicsCaptureItem item = null;
        unsafe
        {
            var guid = GraphicsCaptureItemGuid;
            var guidPointer = (Guid*)Unsafe.AsPointer(ref guid);
            var raw = Marshal.GetIUnknownForObject(callback(interop, guidPointer));
            item = GraphicsCaptureItem.FromAbi(raw);
            Marshal.Release(raw);
        }
        return item;
    }
}