using TranslationOffice.Domain;

namespace TranslationOffice.Api
{
    public class TranslatorMutations
    {
        public async Task<AddTranslatorPayload> AddTranslatorAsync(TranslatorAddDto input, [Service] ITranslatorAddCommand addCommand, CancellationToken ct)
        {
            var newTranslator = await addCommand.AddAsync(input, ct);
            return new AddTranslatorPayload(newTranslator);
        }
    }
}
