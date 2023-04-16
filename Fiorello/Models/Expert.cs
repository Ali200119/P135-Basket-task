using System;
namespace Fiorello.Models
{
	public class Expert: BaseEntity
	{
		public string Title { get; set; }
		public string Description { get; set; }
		public ICollection<Person> Persons { get; set; }
	}
}