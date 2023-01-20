namespace Models
{
	public class ToDoItem
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public bool Done { get; set; }
		public int ToDoListId { get; set; }
		public ToDoList ToDoList { get; set; }
	}
}
