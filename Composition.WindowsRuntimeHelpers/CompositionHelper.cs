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

 

namespace Composition.WindowsRuntimeHelpers
{
    using Windows.Win32.Foundation;
    using Windows.Win32.System.WinRT;
    using Windows.Win32.Graphics.Dxgi;
    using Windows.Win32.System.WinRT.Composition;
    using System.Runtime.InteropServices;
    using Windows.UI.Composition;
    using WinRT;
    public static class CompositionHelper
    {
        public static CompositionTarget CreateDesktopWindowTarget(this Compositor compositor, HWND hwnd, bool isTopmost)
        {
            var desktopInterop = compositor.As<ICompositorDesktopInterop>();
            desktopInterop.CreateDesktopWindowTarget(hwnd, isTopmost, out var target);
            return target;
        }

        public static ICompositionSurface CreateCompositionSurfaceForSwapChain(this Compositor compositor, IDXGISwapChain1 swapChain)
        {
            var interop = compositor.As<ICompositorInterop>();
            interop.CreateCompositionSurfaceForSwapChain(swapChain, out var raw);
            var rawPtr = Marshal.GetIUnknownForObject(raw);
            var result = MarshalInterface<ICompositionSurface>.FromAbi(rawPtr);
            Marshal.Release(rawPtr);
            return result;
        }
    }
}