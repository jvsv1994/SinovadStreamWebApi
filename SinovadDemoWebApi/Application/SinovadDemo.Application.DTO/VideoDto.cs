using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

#nullable disable

namespace SinovadDemo.Application.DTO
{
    public class VideoDto
    {
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string PhysicalPath { get; set; }
        public string AccountId { get; set; }
        public int AccountServerId { get; set; }
        public int AccountStorageId { get; set; }
        public int AccountStorageTypeId { get; set; }
        public int VideoId { get; set; }
        public int MovieId { get; set; }
        public int TvSerieId { get; set; }
        public int EpisodeId { get; set; }
        public int? TmdbId { get; set; }
        public string? Imdbid { get; set; }
        public int Year { get; set; }
        public int EpisodeNumber { get; set; }
        public int SeasonNumber { get; set; }
        public string EpisodeName { get; set; }
        public string HostUrl { get; set; }

    }
}
