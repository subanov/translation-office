using TranslationOffice.Domain;

namespace TranslationOffice.Api;

public sealed class AddTranslatorPayload
{
    public Translator Translator { get; }

    public AddTranslatorPayload(Translator translator)
    {
        Translator = translator;
    }
}