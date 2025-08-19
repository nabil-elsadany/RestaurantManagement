using Microsoft.AspNetCore.Mvc;
using RestaurantManagement.Models;
using RestaurantManagement.Models.Dtos;

namespace RestaurantManagement.Reposetories.IReposetory
{
    public interface ICategoryReposetory : IReposetory<Category>
    {

        Task<CategoryOutputDto> CreateCategoryAsync(CreateEmailWithMilkitDto dto,CancellationToken ct = default);
        
    }
}
