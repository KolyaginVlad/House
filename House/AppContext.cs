using System.Data.Entity;

namespace House
{
    /// <summary>
    /// Класс, осуществляющий подключение и работу с БД
    /// </summary>
    class AppContext : DbContext
    {
        /// <summary>
        /// Объект, позволяющей работать с таблицей квартир
        /// </summary>
        public DbSet<Flat> Flats { get; set; }

        /// <summary>
        /// Объект, позволяющий работать с таблицей жильцов
        /// </summary>
        public DbSet<Tenant> Tenants { get; set; }

        /// <summary>
        /// Конструктор, позволяющий создать подключение к БД
        /// </summary>
        public AppContext() : base("DefaultConnection") { }
    }
}
