
public interface IDreamInterpretationService
{
    Task<List<string>> InterpretDreamAsync(string userDream, string apiKey, string filePath);
}

