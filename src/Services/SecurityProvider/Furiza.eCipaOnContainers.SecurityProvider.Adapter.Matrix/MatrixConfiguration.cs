using System.ComponentModel.DataAnnotations;

namespace Furiza.eCipaOnContainers.SecurityProvider.Adapter.Matrix
{
    public class MatrixConfiguration
    {
        [Required]
        public string LocksmithServiceUrl { get; set; }
    }
}