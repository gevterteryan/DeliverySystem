using ApiLayer.Models;
using AutoMapper;
using Data_Access.ReposInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CategoryController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly ICategoryRepository categoryRepository;
        public CategoryController(IMapper mapper, ICategoryRepository categoryRepository)
        {
            categoryRepository = this.categoryRepository;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<IEnumerable<CategoryDto>> GetAllCategories()
        {
            return (await categoryRepository.GetCategoriesAsync()).Select(item => mapper.Map<CategoryDto>(item));
        }
    }
}
