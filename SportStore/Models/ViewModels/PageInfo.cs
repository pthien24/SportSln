﻿namespace SportStore.Models.ViewModels
{
    public class PageInfo
    {
        public int TotalItem {  get; set; }
        public int ItemPerPage{ get; set; }
        public int CurrentPage { get; set; }
        public int TotalPage =>(int)Math.Ceiling((decimal)TotalItem / ItemPerPage);

    }
}
