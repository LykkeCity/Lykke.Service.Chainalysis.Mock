using System.ComponentModel.DataAnnotations;

namespace Lykke.Service.Chainalysis.Mock.Contracts
{
    public class CommentModel
    {
        [Required]
        public string Comment { get; set; }
    }
}
