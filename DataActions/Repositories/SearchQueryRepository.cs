using DataActions.DataModels;

namespace DataActions.Repositories
{
    public class SearchQueryRepository
    {
        private readonly ApplicationDbContext _context;

        public SearchQueryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task SaveSearchQueryAsync(SearchQuery searchQuery)
        {
            _context.SearchQueries.Add(searchQuery);
            await _context.SaveChangesAsync();
        }
    }

}
