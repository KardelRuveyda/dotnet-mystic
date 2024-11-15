using System.ComponentModel.DataAnnotations;

namespace DreamInterpretationBotAPI.Models.Requests
{
    // Request modeli
    public class DreamRequest
    {
        [MinLength(1, ErrorMessage = "Dream cannot be empty.")]
        public required string Dream { get; set; }
    }
}
