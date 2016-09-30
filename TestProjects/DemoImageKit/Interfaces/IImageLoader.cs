using System.Threading.Tasks;

namespace DemoImageKit.Interfaces
{
    public interface IImageLoader
    {
        Task<byte[]> GetImage();

        Task<string[]> GetImageDetails(byte[] image);
    }
}