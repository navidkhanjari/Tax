namespace CoreLayer.Utilities.Paging
{
	public class Paging<T>
	{
		#region (Fields)
		public Int32 CurrentPage { get; set; }

		public Int32 PagesCount { get; set; }

		public Int32 EntitiesCount { get; set; }

		public Int32 StartPage { get; set; }

		public Int32 EndPage { get; set; }

		public Int32 PageSize { get; set; }

		public Int32 StartPosition { get; set; }

		public Int32 Step { get; set; }

		public List<T> Entities { get; set; }

		#endregion

		#region (Methods)
		#region (Constructor)
		public Paging()
		{
			this.PageSize = 9;
			this.CurrentPage = 1;
			this.Step = 5;
		}
		#endregion

		#region (Build)
		public Paging<T> Build(Int32 EntitiesCount)
		{
			this.PagesCount = (Int32)Math.Ceiling(EntitiesCount / (Double)this.PageSize);

			this.EntitiesCount = EntitiesCount;
			this.StartPosition = (CurrentPage - 1) * this.PageSize;

			this.StartPage = (this.CurrentPage - this.Step) <= 0 ? 1 : (this.CurrentPage - this.Step);
			this.EndPage = (this.CurrentPage + Step) > this.PagesCount ? this.PagesCount : (this.CurrentPage + this.Step);

			return this;
		}
		#endregion

		#region (Set Entities)
		public Paging<T> SetEntities(IQueryable<T> Queryable)
		{
			Entities = Queryable
				.Skip(StartPosition)
				.Take(PageSize)
				.ToList();
			return this;
		}
		#endregion
		#endregion
	}
}
