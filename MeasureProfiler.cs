﻿using System;
using JetBrains.Profiler.Api.Impl;
using JetBrains.Profiler.Api.Impl.Unix;
using JetBrains.Profiler.Api.Impl.Windows;

// ReSharper disable UnusedMember.Global

namespace JetBrains.Profiler.Api
{
  public static class MeasureProfiler
  {
    public static bool WaitForReady(TimeSpan timeout)
    {
      switch (Helper.Platform)
      {
      case PlatformId.Linux:
        return LinuxHelper.WaitForReadySignal(timeout) &&
               LinuxHelper.IsCoreApiLoaded() &&
               Helper.ThrowOnError(CoreApiSo.V1_Measure_CheckActive(Helper.Id, out _));
      case PlatformId.MacOsX:
        return MacOsXHelper.WaitForReadySignal(timeout) &&
               MacOsXHelper.IsCoreApiLoaded() &&
               Helper.ThrowOnError(CoreApiDylib.V1_Measure_CheckActive(Helper.Id, out _));
      case PlatformId.Windows:
        return WindowsHelper.WaitForReadySignal(timeout) &&
               WindowsHelper.IsCoreApiLoaded() &&
               Helper.ThrowOnError(CoreApiDll.V1_Measure_CheckActive(Helper.Id, out _));
      default:
        throw new PlatformNotSupportedException();
      }
    }

    public static MeasureFeatures GetFeatures()
    {
      switch (Helper.Platform)
      {
      case PlatformId.Linux:
        if (LinuxHelper.IsCoreApiLoaded())
          if (Helper.ThrowOnError(CoreApiSo.V1_Measure_CheckActive(Helper.Id, out var features)))
            return features;
        break;
      case PlatformId.MacOsX:
        if (MacOsXHelper.IsCoreApiLoaded())
          if (Helper.ThrowOnError(CoreApiDylib.V1_Measure_CheckActive(Helper.Id, out var features)))
            return features;
        break;
      case PlatformId.Windows:
        if (WindowsHelper.IsCoreApiLoaded())
          if (Helper.ThrowOnError(CoreApiDll.V1_Measure_CheckActive(Helper.Id, out var features)))
            return features;
        break;
      default:
        throw new PlatformNotSupportedException();
      }
      return MeasureFeatures.None;
    }

    public static void StartCollecting()
    {
      StartCollecting(null);
    }

    public static void StartCollecting(string groupName)
    {
      switch (Helper.Platform)
      {
      case PlatformId.Linux:
        if (LinuxHelper.IsCoreApiLoaded())
          Helper.ThrowOnError(CoreApiSo.V1_Measure_StartCollecting(Helper.Id, groupName));
        break;
      case PlatformId.MacOsX:
        if (MacOsXHelper.IsCoreApiLoaded())
          Helper.ThrowOnError(CoreApiDylib.V1_Measure_StartCollecting(Helper.Id, groupName));
        break;
      case PlatformId.Windows:
        if (WindowsHelper.IsCoreApiLoaded())
          Helper.ThrowOnError(CoreApiDll.V1_Measure_StartCollecting(Helper.Id, groupName));
        break;
      default:
        throw new PlatformNotSupportedException();
      }
    }

    public static void StopCollecting()
    {
      switch (Helper.Platform)
      {
      case PlatformId.Linux:
        if (LinuxHelper.IsCoreApiLoaded())
          Helper.ThrowOnError(CoreApiSo.V1_Measure_StopCollecting(Helper.Id));
        break;
      case PlatformId.MacOsX:
        if (MacOsXHelper.IsCoreApiLoaded())
          Helper.ThrowOnError(CoreApiDylib.V1_Measure_StopCollecting(Helper.Id));
        break;
      case PlatformId.Windows:
        if (WindowsHelper.IsCoreApiLoaded())
          Helper.ThrowOnError(CoreApiDll.V1_Measure_StopCollecting(Helper.Id));
        break;
      default:
        throw new PlatformNotSupportedException();
      }
    }

    public static void Save()
    {
      Save(null);
    }

    public static void Save(string name)
    {
      switch (Helper.Platform)
      {
      case PlatformId.Linux:
        if (LinuxHelper.IsCoreApiLoaded())
          Helper.ThrowOnError(CoreApiSo.V1_Measure_Save(Helper.Id, name));
        break;
      case PlatformId.MacOsX:
        if (MacOsXHelper.IsCoreApiLoaded())
          Helper.ThrowOnError(CoreApiDylib.V1_Measure_Save(Helper.Id, name));
        break;
      case PlatformId.Windows:
        if (WindowsHelper.IsCoreApiLoaded())
          Helper.ThrowOnError(CoreApiDll.V1_Measure_Save(Helper.Id, name));
        break;
      default:
        throw new PlatformNotSupportedException();
      }
    }

    public static void Drop()
    {
      switch (Helper.Platform)
      {
      case PlatformId.Linux:
        if (LinuxHelper.IsCoreApiLoaded())
          Helper.ThrowOnError(CoreApiSo.V1_Measure_Drop(Helper.Id));
        break;
      case PlatformId.MacOsX:
        if (MacOsXHelper.IsCoreApiLoaded())
          Helper.ThrowOnError(CoreApiDylib.V1_Measure_Drop(Helper.Id));
        break;
      case PlatformId.Windows:
        if (WindowsHelper.IsCoreApiLoaded())
          Helper.ThrowOnError(CoreApiDll.V1_Measure_Drop(Helper.Id));
        break;
      default:
        throw new PlatformNotSupportedException();
      }
    }
  }
}