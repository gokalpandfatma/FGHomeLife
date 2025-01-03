using FGHomeLife.Models.ViewModels;

namespace FGHomeLife.Services.EFServices.Home
{
    public interface IHomeService
    {
        Task<HomeViewModel> GetHomePageDataAsync();
    }
}