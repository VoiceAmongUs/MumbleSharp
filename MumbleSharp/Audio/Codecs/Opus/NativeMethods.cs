// 
// Author: John Carruthers (johnc@frag-labs.com)
// 
// Copyright (C) 2013 John Carruthers
// 
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
//  
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
//  
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
// 

using System;
using System.Runtime.InteropServices;

namespace MumbleSharp.Audio.Codecs.Opus
{

    /// <summary>
    /// Wraps the Opus API.
    /// </summary>
    internal class NativeMethods
    {

        const string LibraryName = "libopus";

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr opus_encoder_create(int sampleRate, int channelCount, int application, out IntPtr error);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void opus_encoder_destroy(IntPtr encoder);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int opus_encode(IntPtr encoder, IntPtr pcm, int frameSize, IntPtr data, int maxDataBytes);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr opus_decoder_create(int sampleRate, int channelCount, out IntPtr error);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void opus_decoder_destroy(IntPtr decoder);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int opus_decode(IntPtr decoder, IntPtr data, int len, IntPtr pcm, int frameSize, int decodeFec);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int opus_packet_get_nb_channels(IntPtr data);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int opus_packet_get_nb_samples(IntPtr data, int len, int sampleRate);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int opus_encoder_ctl(IntPtr encoder, Ctl request, int value);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "opus_encoder_ctl")]
        internal static extern int opus_encoder_ctl_out(IntPtr encoder, Ctl request, out int value);


        internal enum Ctl
        {
            SetBitrateRequest = 4002,
            GetBitrateRequest = 4003,
            SetInbandFecRequest = 4012,
            GetInbandFecRequest = 4013
        }

        internal enum OpusErrors
        {
            Ok = 0,
            BadArgument = -1,
            BufferToSmall = -2,
            InternalError = -3,
            InvalidPacket = -4,
            NotImplemented = -5,
            InvalidState = -6,
            AllocFail = -7
        }

    }

}