﻿namespace FirstSpaceApi.Shared.ViewModels
{
    public class PagedList<T> : List<T>
    {
        public MetaData metaData { get; set; }
        public PagedList(List<T> items, int count, int pageNum, int pageSize) {

            metaData = new MetaData
            {
                TotalCount = count,
                CurrentPage = pageNum,
                PageSize = pageSize,
                TotalPages = (int)Math.Ceiling(count/ (double)pageSize)
            };

            AddRange(items);
        }

        public static PagedList<T> ToPagedList(IEnumerable<T> source, int pageNumber, int pageSize)
        {
            var count = source.Count();
            var items = source
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize).ToList();
            
            return new PagedList<T>(items, count, pageNumber, pageSize);
        }
    }

    public class MetaData
    {
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public bool HasPrevious => CurrentPage > 1;
        public bool HasNext => CurrentPage < TotalPages;
    }


}
