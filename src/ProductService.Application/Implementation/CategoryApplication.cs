using ProductService.Application.Dto.Category;
using ProductService.Application.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProductService.Application.Implementation
{
    public class CategoryApplication : ICategoryApplication
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryApplication(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<int> AddAsync(AddCategoryCommand category, CancellationToken cancellationToken)
        {
            return await _categoryRepository.AddAsync(category, cancellationToken);
        }

        public async Task ChangeAsync(ChangeCategoryCommand category, CancellationToken cancellationToken)
        {
            await _categoryRepository.ChangeAsync(category, cancellationToken);
        }

        public async Task DeleteAsync(DeleteCategoryCommand command, CancellationToken cancellationToken)
        {
            await _categoryRepository.DeleteAsync(command.CategoryId, cancellationToken);
        }


        ///<inheritdoc/>
        public async Task<IEnumerable<CategoryDto>> ListByPageAsync(ListCategoriesByPageQuery query, CancellationToken cancellationToken)
        {
            var categories = await _categoryRepository.ListByPageAsync(query.PageNumber, query.PageSize, cancellationToken);

            return categories.ToList();
        }
    }
}
