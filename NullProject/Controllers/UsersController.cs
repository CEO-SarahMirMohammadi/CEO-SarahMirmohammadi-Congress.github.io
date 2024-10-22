using AutoMapper;
using congress.DTOs;
using congress.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Session7.Models;

namespace congress.Controllers
{
	public class UsersController : Controller
	{
		private readonly AppDbContext Db;
		private readonly IMapper mapper;

		public UsersController(AppDbContext db, IMapper mapper)
		{
			Db = db;
			this.mapper = mapper;
		}
		public async Task<IActionResult> Add()
		{
			return View();
		}
		public async Task<IActionResult> search()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Add(UsersDTO dto)
		{
			var model = mapper.Map<Users>(dto);


			await Db.Users.AddAsync(model);
			await Db.SaveChangesAsync();

			return RedirectToAction("List");
		}
		public async Task<IActionResult> List()
		{
			var Users = await Db.Users.ToListAsync();
			var model = mapper.Map<List<UsersDTO>>(Users);
			return View(model);
		}
		public async Task<IActionResult> Update(int id)
		{
			var Users = await Db.Users.FirstOrDefaultAsync(x => x.Id == id);
			var model = mapper.Map<UsersDTO>(Users);

			return View(model);
		}
		//public IActionResult search(string NationalCode)
		//{
			//var Users = Db.Users.FirstOrDefault(x => x.NationalCode == NationalCode);
			//var model = mapper.Map<UsersDTO>(Users);

			//return View(model);
		//}

		[HttpPost]
		public async Task<IActionResult> Update(UsersDTO dto)
		{
			var Users = await Db.Users.FirstOrDefaultAsync(x => x.NationalCode == dto.NationalCode);

			Users.Name = dto.Name;
			Users.LastName = dto.LastName;
			Users.Phone = dto.Phone;

			 Db.Users.Update(Users);
			 Db.SaveChanges();
			return RedirectToAction("List");
		}
		public IActionResult Delete(int id)
		{
			var Users = Db.Users.FirstOrDefault(x => id == x.Id);
			Db.Users.Remove(Users);
			Db.SaveChanges();
			return RedirectToAction("List");
		}
	}
}
