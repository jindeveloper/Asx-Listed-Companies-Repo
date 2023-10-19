namespace Ct.Interview.Infrastructure.Data.DataSeed
{
    public class ListedCompanySeedConfiguration : IEntityTypeConfiguration<ListedCompany>
    {
        public void Configure(EntityTypeBuilder<ListedCompany> builder)
        {
            var fullPath = CsvFilePath.GetFilePath();

            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                MissingFieldFound = null
            };

            using (var reader = new StreamReader(fullPath))
            using (var csvReader = new CsvReader(reader, config))
            {
                csvReader.Read();
                csvReader.Read();
                csvReader.ReadHeader();

                var records = csvReader.GetRecords<ListedCompany>().ToList();
                
                records.ForEach(item => item.Id = Guid.NewGuid());

                builder.HasData(records);

            }
        }
    }
}
