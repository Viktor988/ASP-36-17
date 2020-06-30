using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Text.RegularExpressions;

namespace ApiNovine.Domain.Entities
{
	public class Post:Entity
	{
	
		public string Title { get; set; }
		
		public string Content { get; set; }
		public DateTime DateCreated { get; set; }
		public Category Category { get; set; }
		public Picture Picture { get; set; }
		public int CategoryId { get; set; }
		public int PictureId { get; set; }
		public virtual ICollection<TagPost> TagPosts { get; set; }
						= new HashSet<TagPost>();

		public IEnumerable<Comment> Comments { get; set; } = new List<Comment>();
		public IEnumerable<Rate> Rates { get; set; } = new List<Rate>();

	}
}
