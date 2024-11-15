using DreamInterpretationBotAPI.Models.Constants;
using DreamInterpretationBotAPI.Models.Requests;
using DreamInterpretationBotAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;

namespace DreamInterpretationBotAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DreamInterpretationController : ControllerBase
    {
        private readonly IDreamInterpretationService _dreamInterpretationService;
        private readonly OpenAIConstants _openAIConstants;
        public DreamInterpretationController(IConfiguration configuration, IOptions<OpenAIConstants> openAIConstants, IDreamInterpretationService dreamInterpretationService)
        {
            // API Key ve dosya yolunu appsettings.json'dan Option Pattern ile birlikte program.cs içerisinde doğrulayıp alıyoruz
            _openAIConstants = openAIConstants.Value;
            // DreamInterpretationService'i başlat
            _dreamInterpretationService = dreamInterpretationService;
        }
        [HttpPost("interpret")]
        public async Task<IActionResult> InterpretDream([FromBody] DreamRequest dreamRequest)
        {
            var interpretation = await _dreamInterpretationService.InterpretDreamAsync(dreamRequest.Dream, _openAIConstants.ApiKey, _openAIConstants.FilePath);
            return Ok(interpretation);
        }
    }


}
