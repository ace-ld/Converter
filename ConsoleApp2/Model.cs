namespace ConsoleApp2
{
    public class Model
    {
        // ISO Букв. код валюты
        public string CharCode { get; set; }
        // Название валюты
        public string Name { get; set; }
        // Значение
        public decimal Value { get; set; }

        // базовая валюта рубль РФ
        public decimal Curse(decimal valute = 100) => valute / Value;

        public decimal Converter(decimal sum, string valute) 
        {
            // [Сумма в евро]=100 * 100 * 1,73(курс евро к рублю) / 100 * 1,94(курс доллара к рублю)

            if (CharCode == valute)
            {
                
            }

            decimal x = sum * sum * Curse();
            decimal y = sum * Curse();
            return _ = x / y;
        }
    }
}