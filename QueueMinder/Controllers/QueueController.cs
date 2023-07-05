using System.Collections;
using Microsoft.AspNetCore.DataProtection.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QueueMinder.Repositories.Interfaces;
using QueueMinder.Domain.Models;

namespace QueueMinder.Controllers
{
	[Route("api/v1/[controller]")]
	[ApiController]
	public class QueueController : ControllerBase
	{
		private readonly List<ManagedQueue> _queues;
		private readonly IRepository _repository;

		public QueueController(IRepository repository)
		{
			this._repository = repository;
			SetUpRepo();
		}

		private Task SetUpRepo()
		{
			var _queue = new ManagedQueue("Demo Queue")
			{
				Id = 1, Created = DateTime.UtcNow, IsDeleted = false, QueueMembers = new List<QueueMember>(0)
			};

			_repository.Queue.Add(_queue);
			_repository.Commit();
		}

		[HttpGet]
		public IActionResult GetAll()
		{
			return Ok(_repository.Queue);
		}

		[HttpGet("id")]
		public async Task<IActionResult> Get(int id)
		{
			if (_repository.Queue.All(x => x.Id != id))
			{
				throw new ApplicationException($"Queue with id: {id} not found.");
			}

			return Ok(_repository.Queue.FirstOrDefaultAsync(x=> x.Id == id));
		}

		[HttpPost]
		public IActionResult Add(ManagedQueue queue)
		{
			_queues.Add(queue);
			return Ok();
		}



	}
}
