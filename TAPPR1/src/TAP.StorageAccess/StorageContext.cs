using System.IO;
using System.Threading.Tasks;

namespace TAPSS.StorageAccess
{
    public interface StorageContext
    {
        public Task<string> uploadAsync(Stream stream, string fileName, bool overwrite);

        public Task<bool> deleteAsync(string fileUri);
    }
}