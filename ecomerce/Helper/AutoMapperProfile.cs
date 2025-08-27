using AutoMapper;
using ecomerce.Data;
using ecomerce.ViewModel;

namespace ecomerce.Helper
{
	public class AutoMapperProfile: Profile
	{
		public AutoMapperProfile()
		{
			CreateMap<AccountRegister, KhachHang>();
		}
	}
}
