using BackendAssignment.Data;
using BackendAssignment.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackendAssignment.Controllers
{
    [Route("api/todos/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly AppDbContext _context;
        public TodoController(AppDbContext context)
        {
            _context = context;
        }

        // GET
        [HttpGet(Name = "GetAllTodos")]
        public async Task<ActionResult<IEnumerable<TodoItem>>> GetTodoItems()
        {
            var todoItems = await _context.TodoItems.ToListAsync();
            return Ok(todoItems);
        }


        [HttpGet("{id}", Name = "GetTodoItem")]
        public async Task<ActionResult<TodoItem>> GetTodoItem(int id)
        {
            var todoItem = await _context.TodoItems.FindAsync(id);
            if (todoItem == null)
            {
                return NotFound();
            }
            return Ok(todoItem);
        }

        [HttpPost(Name = "CreateTodoItem")]
        public async Task<ActionResult<TodoItem>> CreateTodoItem(TodoItem todoItem)
        {
            await _context.TodoItems.AddAsync(todoItem);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id}", Name = "UpdateTodoItem")]
        public async Task<ActionResult<TodoItem>> UpdateTodoItem(int id, TodoItem todoItem)
        {
            var existingTask = await _context.TodoItems.FindAsync(id);

            if (existingTask == null)
            {
                return NotFound();
            }

            existingTask.Title = todoItem.Title;
            existingTask.Description = todoItem.Description;
            existingTask.IsCompleted = todoItem.IsCompleted;


            // Save the changes to the database
            await _context.SaveChangesAsync();

            // Return the updated TodoItem as the response
            return Ok(existingTask);
        }

        [HttpDelete("{id}", Name = "DeleteTodoItem")]
        public async Task<ActionResult<TodoItem>> DeleteTodoItem(int id)
        {
            var todoItem = await _context.TodoItems.FindAsync(id);
            if (todoItem == null)
            {
                return NotFound();
            }

            _context.TodoItems.Remove(todoItem);
            await _context.SaveChangesAsync();

            return Ok(todoItem);
        }
    }
}
