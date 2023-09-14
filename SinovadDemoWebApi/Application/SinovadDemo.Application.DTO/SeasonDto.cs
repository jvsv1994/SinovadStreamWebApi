﻿using System;
using System.Collections.Generic;



namespace SinovadDemo.Application.DTO
{
    public class SeasonDto
    {

        public int Id { get; set; }
        public int? SeasonNumber { get; set; }
        public string Name { get; set; }
        public string Summary { get; set; }
        public string Overview { get; set; }
        public string PosterPath { get; set; }
        public int TvSerieId { get; set; }
        public List<EpisodeDto> ListEpisodes { get; set; }

    }
}
