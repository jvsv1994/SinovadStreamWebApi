﻿namespace SinovadDemo.Domain.Enums
{
    public enum CatalogEnum
    {
        MediaServerState = 1,
        MediaType = 2,
        VideoTransmissionType = 3,
        TranscoderPreset=4,
        IconType = 5,
        LinkedAccountProvider = 6
    }

    public enum MediaServerState
    {
        Started = 1,
        Stopped = 2
    }

    public enum MediaType
    {
        Movie = 1,
        TvSerie = 2
    }

    public enum VideoTransmissionType
    {
        NORMAL=1,
        MPEGDASH=2,
        HLS=3
    }
    public enum TranscoderPreset
    {
        Ultrafast = 1,
        Superfast = 2,
        Veryfast = 3,
        Faster = 4,
        Fast = 5,
        Medium = 6,
        Slow = 7,
        Slower=8,
        Veryslow = 9
    }

    public enum RoleType
    {
        MainAdministrator = 1,
        MediaAdministrator = 2
    }

    public enum LogType
    {
        Information = 1,
        Error = 2
    }

    public enum IconType
    {
        Image = 1,
        FontAwesome = 2
    }

    public enum LinkedAccountProvider
    {
        Google = 1,
        Facebook = 2,
        Apple = 3
    }

}
