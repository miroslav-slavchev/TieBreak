namespace SwagLabs.Application.Models
{
    public class PriceModel
    {
        public string Text { get; set; }
        public decimal Value { get; set; }
        public string Currency { get; set; }

        public PriceModel(string priceString)
        {
            if (string.IsNullOrWhiteSpace(priceString))
                throw new ArgumentException("Price string cannot be null or empty.");

            string trimmed = priceString.Trim();
            string currency = new(trimmed.TakeWhile(c => !char.IsDigit(c)).ToArray());
            string numericPart = new(trimmed.SkipWhile(c => !char.IsDigit(c) && c != '-').ToArray());

            if (!decimal.TryParse(numericPart, out decimal value))
                throw new FormatException($"Cannot parse numeric value from '{priceString}'.");

            Text = priceString;
            Currency = currency;
            Value = value;
        }
    }

}
