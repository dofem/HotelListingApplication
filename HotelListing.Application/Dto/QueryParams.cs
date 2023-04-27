﻿namespace HotelListing.Application.Dto
{
    public class QueryParams
    {
        private int _pagesize = 15;
        public int StartIndex { get; set; }
        public int PageNumber { get; set; }
        public int PageSize
        {
            get
            {
                return _pagesize;
            }
            set
            {
                _pagesize = value;
            }
        }
    }
}
