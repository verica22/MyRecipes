﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace ItLabs.MyRecipes.Data
{
    public class Paging
    {
        public const int pageSize = 2;
        //   int pageNumber = (page ?? 1);
    }
    //public class PaginatedList<T> : List<T>
    //{

    //    public int PageIndex { get; private set; }
    //    public int PageSize { get; private set; }
    //    public int TotalCount { get; private set; }
    //    public int TotalPages { get; private set; }

    //    public PaginatedList(IQueryable<T> source, int pageIndex, int pageSize)
    //    {
    //        PageIndex = pageIndex;
    //        PageSize = pageSize;
    //        TotalCount = source.Count();
    //        TotalPages = (int)Math.Ceiling(TotalCount / (double)PageSize);

    //        AddRange(source.Skip(PageIndex * PageSize).Take(PageSize));
    //    }

    //    public bool HasPreviousPage
    //    {
    //        get
    //        {
    //            return (PageIndex > 0);
    //        }
    //    }

    //    public bool HasNextPage
    //    {
    //        get
    //        {
    //            return (PageIndex + 1 < TotalPages);
    //        }
    //    }
    //}

}