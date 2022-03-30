using System;
using System.Collections.Generic;
using HentaiSite.Enums;

namespace HentaiSite.Models
{
    public class QueryData
    {
        public string s { get; set; }

        public int PostsPerPage { get; set; }

        private int _Page = 1;
        public int Page
        {
            get
            {
                return _Page;
            }
            set
            {
                if (value < 1)
                    _Page = 1;
                else
                    _Page = value;
            }
        }

        public int? ReleaseYear { get; set; }
        public List<int> TagIDs { get; set; }

        private OrderBy _orderBy { get; set; }
        public OrderBy orderBy
        {
            get
            {
                return _orderBy;
            }
            set
            {
                SetOrderBy(value);
            }
        }

        private string _orderByString { get; set; }
        public string orderByString
        {
            get
            {
                return _orderByString;
            }
            set
            {
                SetOrderBy(value);
            }
        }

        public void SetOrderBy(string value)
        {
            OrderBy orderBy = OrderByExntension.StringToOrderBy(value);
            SetOrderBy(orderBy);
        }

        private void SetOrderBy(OrderBy value)
        {
            switch(value)
            {
                case OrderBy.Name:
                    _orderByString = "name";
                    break;
                case OrderBy.NameDescending:
                    _orderByString = "name-d";
                    break;
                case OrderBy.Rating:
                    _orderByString = "rating";
                    break;
                case OrderBy.RatingDescending:
                    _orderByString = "rating-d";
                    break;
                case OrderBy.Time:
                    _orderByString = "time";
                    break;
                case OrderBy.TimeDescending:
                    _orderByString = "time-d";
                    break;
                case OrderBy.Views:
                    _orderByString = "views";
                    break;
                case OrderBy.ViewsDescending:
                    _orderByString = "views-d";
                    break;
                default:
                    throw new ArgumentException($"{value} - ENUM doesn't exist");
            }
            _orderBy = value;
        }

        


    }
}
