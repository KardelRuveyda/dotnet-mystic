using DreamInterpretationBotAPI.Requests;
using DreamInterpretationBotAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace DreamInterpretationBotAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DreamInterpretationController : ControllerBase
    {
        private readonly DreamInterpretationService _dreamInterpretationService;
        private readonly string _apiKey;
        private readonly string _filePath;

        public DreamInterpretationController(IConfiguration configuration)
        {
            // API Key ve dosya yolunu appsettings.json'dan alıyoruz
            _apiKey = configuration["OpenAI:ApiKey"];
            _filePath = configuration["OpenAI:FilePath"];

            // DreamInterpretationService'i başlat
            _dreamInterpretationService = new DreamInterpretationService();
        }

        [HttpPost("interpret")]
        public async Task<IActionResult> InterpretDream([FromBody] DreamRequest dreamRequest)
        {
            if (string.IsNullOrEmpty(dreamRequest.Dream))
            {
                return BadRequest("Lütfen bir rüya girin.");
            }
            
            var interpretation = await _dreamInterpretationService.InterpretDreamAsync(dreamRequest.Dream, _apiKey, _filePath);

            return Ok(interpretation);
        }
    }


}
