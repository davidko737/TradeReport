using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using TradeReport.Common;
using TradeReport.Entity;
using TradeReport.Repository;

namespace TradeReport.Helper
{
    public static class TRCsvHelper
    {
        public static CsvReader GetReader(string path)
        {
            var csvConfig = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = ",",
            };
            var reader = new StreamReader(path);
            return new CsvReader(reader, csvConfig);
        }

        public static CsvWriter GetWritter(string outputPath)
        {
            var writer = new StreamWriter(outputPath);
            return new CsvWriter(writer, CultureInfo.InvariantCulture);
        }

        public static string GenTradeReport(Product product, Broker broker)
        {
            var path = TRCsvPath.GetOutPath(product.Name, broker.Name);
            var writer = TRCsvHelper.GetWritter(path);
            var repo = new DerivativesTradeRepository();
            var records = repo.GetAllFilterBy(product.Id, broker.Id);

            using (writer)
            {
                foreach (var property in typeof(ReportDTO).GetProperties())
                {
                    writer.WriteField(property.Name.Replace('_', ' '));
                }
                writer.NextRecord();

                foreach (DerivativesTrade trade in records)
                {
                    var outputDTO = new ReportDTO(trade);
                    writer.WriteRecord(outputDTO);
                    writer.NextRecord();
                }
            }
            return path;
        }
    }
}

