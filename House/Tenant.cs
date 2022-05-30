namespace House
{
    /// <summary>
    /// Класс-модель жильца. Имена полей совпадают с именами столбцов в БД
    /// </summary>
    class Tenant
    {
        /// <summary>
        /// Id жильца
        /// </summary>
        public int tenantId { get; set; }
        /// <summary>
        /// Доход
        /// </summary>
        public decimal income { get; set; }
        /// <summary>
        /// Id квартиры 
        /// </summary>
        public int flatId { get; set; }
        /// <summary>
        /// Имя
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// Фамилия
        /// </summary>
        public string surname { get; set; }
        /// <summary>
        /// Отчество
        /// </summary>
        public string patronymic { get; set; }

        public Tenant()
        {
        }

        public Tenant(int tenantId, string name, string surname, string patronymic, decimal income, int flatId)
        {
            this.tenantId = tenantId;
            this.name = name;
            this.surname = surname;
            this.patronymic = patronymic;
            this.income = income;
            this.flatId = flatId;
        }
        public Tenant(string name, string surname, string patronymic, decimal income, int flatId)
        {
            this.name = name;
            this.surname = surname;
            this.patronymic = patronymic;
            this.income = income;
            this.flatId = flatId;
        }
    }
}
