using FGHomeLife.Models.ViewModels;

namespace FGHomeLife.Services.Interfaces
{
    public interface IHomeService
    {
        Task<HomeViewModel> GetHomePageDataAsync();
    }
}