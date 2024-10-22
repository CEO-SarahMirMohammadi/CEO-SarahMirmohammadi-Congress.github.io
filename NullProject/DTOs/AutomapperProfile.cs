using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Threading.Tasks;
using AutoMapper;
using congress.Models;

namespace congress.DTOs
{
	public class AutomapperProfile : Profile
	{

		public AutomapperProfile()
		{
			CreateMap<Users, UsersDTO>().ReverseMap();


		}

	}
}
