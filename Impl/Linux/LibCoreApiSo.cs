﻿using System.Runtime.InteropServices;

namespace JetBrains.Profiler.Api.Impl.Linux
{
  internal static class LibCoreApiSo
  {
    public const string LibraryName = "libJetBrains.Profiler.CoreApi.so";

    #region Measure

    [DllImport(LibraryName)]
    public static extern HResults V1_Measure_CheckActive(uint id, out MeasureFeatures features);

    [DllImport(LibraryName)]
    public static extern HResults V1_Measure_StartCollecting(uint id, [MarshalAs(UnmanagedType.LPWStr)] string groupName);

    [DllImport(LibraryName)]
    public static extern HResults V1_Measure_StopCollecting(uint id);

    [DllImport(LibraryName)]
    public static extern HResults V1_Measure_Save(uint id, [MarshalAs(UnmanagedType.LPWStr)] string name);

    [DllImport(LibraryName)]
    public static extern HResults V1_Measure_Drop(uint id);

    [DllImport(LibraryName)]
    public static extern HResults V1_Measure_Detach(uint id);

    #endregion

    #region Memory

    [DllImport(LibraryName)]
    public static extern HResults V1_Memory_CheckActive(uint id, out MemoryFeatures features);

    [DllImport(LibraryName)]
    public static extern HResults V1_Memory_GetSnapshot(uint id, [MarshalAs(UnmanagedType.LPWStr)] string name);

    [DllImport(LibraryName)]
    public static extern HResults V1_Memory_ForceGc(uint id);

    [DllImport(LibraryName)]
    public static extern HResults V1_Memory_CollectAllocations(uint id, bool enable);

    [DllImport(LibraryName)]
    public static extern HResults V1_Memory_Detach(uint id);

    #endregion
  }
}