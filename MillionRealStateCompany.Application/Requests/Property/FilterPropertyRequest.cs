﻿namespace MillionRealStateCompany.Application.Requests.Property
{
    public class FilterPropertyRequest
    {
        public string? NameFilter { get; set; }
        public decimal? MaxPriceFilter { get; set; }
        public decimal? MinPriceFilter { get; set; }
        public int? MaxYearFilter { get; set; }
        public int? MinYearFilter { get; set; }
        public bool? EnableFilter { get; set; }
        public string? NameOwnerFilter { get; set; }
    }
}
