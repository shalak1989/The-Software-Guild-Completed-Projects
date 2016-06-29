using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FlooringMastery.Data
{
    public class TaxRepository
    {
        private string _filePath = @"Datafiles\Taxes.txt";

        public List<Tax> GetAllTaxes()
        {
            List<Tax> taxes = new List<Tax>();

            var reader = File.ReadAllLines(_filePath);

            for (int i = 1; i < reader.Length; i++)
            {
                var columns = reader[i].Split(',');

                var tax = new Tax();

                tax.State = columns[0];
                tax.TaxRate = decimal.Parse(columns[1]);

                taxes.Add(tax);
            }

            return taxes;
        }

    }
}
