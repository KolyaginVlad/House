namespace House
{
    /// <summary>
    /// Класс-модель квартиры. Имена полей совпадают с именами столбцов в БД
    /// </summary>
    class Flat
    {
        /// <summary>
        /// Id квартиры
        /// </summary>
        public int flatId { get; set; }
        /// <summary>
        /// Номер квартиры
        /// </summary>
        public int flat_num { get; set; }
        /// <summary>
        /// Аренда квартиры
        /// </summary>
        public decimal rent { get; set; }
        /// <summary>
        /// Электроэнергия
        /// </summary>
        public decimal energy { get; set; }
        /// <summary>
        /// Холодная вода
        /// </summary>
        public decimal cold_water { get; set; }
        /// <summary>
        /// Горячая вода
        /// </summary>
        public decimal hot_water { get; set; }
        /// <summary>
        /// Газ
        /// </summary>
        public decimal gas { get; set; }


        public Flat() { }

        public Flat(int flat_num, decimal rent, decimal energy, decimal cold_water, decimal hot_water, decimal gas)
        {
            this.rent = rent;
            this.energy = energy;
            this.cold_water = cold_water;
            this.hot_water = hot_water;
            this.gas = gas;
            this.flat_num = flat_num;
        }

        public Flat(int flatId, int flat_num, decimal rent, decimal energy, decimal cold_water, decimal hot_water, decimal gas)
        {
            this.flatId = flatId;
            this.rent = rent;
            this.energy = energy;
            this.cold_water = cold_water;
            this.hot_water = hot_water;
            this.gas = gas;
            this.flat_num = flat_num;
        }
    }
}
