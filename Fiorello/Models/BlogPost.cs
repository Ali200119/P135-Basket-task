using System;
namespace Fiorello.Models
{
	public class BlogPost: BaseEntity
	{
		public string Image { get; set; }
		public DateTime Date { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public int BlogId { get; set; }
		public Blog Blog { get; set; }
	}
}