using System;

namespace NetCoreKit.Domain
{
  public class Criterion
  {
    private const int MaxPageSize = 50;
    private const int ConfigurablePageSize = 10;
    private const string DefaultSortBy = "Id";
    private const string DefaultSortOrder = "desc";

    public Criterion()
    {
      CurrentPage = 1;
      PageSize = ConfigurablePageSize;
    }

    public int CurrentPage { get; set; }

    private int _pageSize = MaxPageSize;
    public int PageSize
    {
      get => _pageSize;
	    set => _pageSize = (value > MaxPageSize) ? MaxPageSize : (value < 1 ? 1 : value);
    }

    private string _sortBy = DefaultSortBy;
    public string SortBy
    {
      get => _sortBy;
      set => _sortBy = string.IsNullOrEmpty(value) ? DefaultSortBy : value;
    }

    private string _sortOrder = DefaultSortOrder;
    public string SortOrder
    {
      get => _sortOrder;
      set => _sortOrder = string.IsNullOrEmpty(value) ? DefaultSortOrder : value;
    }

    public Criterion SetPageSize(int pageSize)
    {
      if (pageSize <= 0)
        throw new Exception("PageSize could not be less than zero.");

      PageSize = pageSize;
      return this;
    }

    public Criterion SetCurrentPage(int currentPage)
    {
      if (currentPage <= 0)
        throw new Exception("CurrentPage could not be less than zero.");

      CurrentPage = currentPage;
      return this;
    }
  }
}
