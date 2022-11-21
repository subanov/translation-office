using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TranslationOffice.Domain;

namespace TranslationOffice.Application.Data
{
    public sealed class TranslatorIdentityValueConverter : ValueConverter<TranslatorIdentity, Guid>
    {
        public TranslatorIdentityValueConverter() : base(i => i.Value, v => new TranslatorIdentity(v))
        {
        }
    }

    public sealed class TranslatorEntityTypeConfiguration : IEntityTypeConfiguration<Translator>
    {
        public void Configure(EntityTypeBuilder<Translator> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id);
            builder.Property(t => t.Name).HasMaxLength(128);
            builder.Property(t => t.Surname).HasMaxLength(128);
            builder.Property(t => t.Patronymic).HasMaxLength(128);
        }
    }
}