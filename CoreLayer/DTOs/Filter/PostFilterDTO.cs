using CoreLayer.Utilities.Paging;
using DataLayer.Entities.Posts;

namespace CoreLayer.DTOs.Filter
{
	public class PostFilterDTO : Paging<Post>
	{
		public string Title { get; set; }
		public string Authour { get; set; }
		public bool FindAll { get; set; }

		public SearchType? Type { get; set; }

		public enum SearchType
		{
			MostVisited,
			Oldest,
			Newest
		}
	}

	public class PostFilterForShowDTO : Paging<Post>
	{
		
	}
}
