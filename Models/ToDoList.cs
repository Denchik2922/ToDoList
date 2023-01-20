﻿namespace Models
{
	public class ToDoList
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public int CategoryId { get; set; }
		public Category Category { get; set; }
		public ICollection<ToDoItem> ToDoItems { get; set;}
	}
}