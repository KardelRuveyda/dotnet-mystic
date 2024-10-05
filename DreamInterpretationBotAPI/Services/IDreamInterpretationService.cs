#pragma warning disable OPENAI001

public interface IDreamInterpretationService
{
    Task<List<string>> InterpretDreamAsync(string userDream, string apiKey, string filePath);
}

#pragma warning restore OPENAI001
