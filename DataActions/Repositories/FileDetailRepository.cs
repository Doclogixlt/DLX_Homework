

using DataActions.DataModels;

namespace DataActions.Repositories
{
    public class FileDetailRepository
    {
        private readonly ApplicationDbContext _context;

        public FileDetailRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task SaveBatchAsync(IEnumerable<FileDetail> fileDetails)
        {
            _context.FileDetails.AddRange(fileDetails);
            await _context.SaveChangesAsync();
        }
    }
}
