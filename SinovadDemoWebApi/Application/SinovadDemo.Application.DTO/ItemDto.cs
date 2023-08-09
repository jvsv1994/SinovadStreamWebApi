﻿using SinovadDemo.Domain.Enums;

#nullable disable

namespace SinovadDemo.Application.DTO
{
    public class ItemDto
    {
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public double CurrentTime { get; set; }
        public double DurationTime { get; set; }
        public int SeasonNumber { get; set; }
        public int EpisodeNumber { get; set; }
        public string Name { get; set; }
        public string Overview { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public DateTime? FirstAirDate { get; set; }
        public DateTime? LastAirDate { get; set; }
        public int? TmdbId { get; set; }
        public string Imdbid { get; set; }
        public string PosterPath { get; set; }
        public string PhysicalPath { get; set; }
        public int TvSerieId { get; set; }
        public int MovieId { get; set; }
        public int GenreId { get; set; }
        public int VideoId { get; set; }
        public Guid MediaServerGuid { get; set; }
        public int MediaServerId { get; set; }
        public int LibraryId { get; set; }
        public Guid LibraryGuid { get; set; }
        public string GenreName { get; set; }
        public string IpAddress { get; set; }
        public string MediaServerUrl { get; set; }
        public MediaServerState MediaServerState { get; set; }
        public MediaType MediaType { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastModified { get; set; }
        public Boolean ContinueVideo { get; set; }

    }
}
