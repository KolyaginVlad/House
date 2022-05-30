using System;
using System.Windows.Forms;

namespace House
{
    /// <summary>
    /// Частичный класс приветственной формы
    /// </summary>
    public partial class HelloForm : Form
    {
        /// <summary>
        /// Инициализация компонентов
        /// </summary>
        public HelloForm()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Обработка работы таймера
        /// </summary>
        /// <param name="sender">Отправитель</param>
        /// <param name="e">Event</param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            new TenantsForm().Show();
            this.Hide();
        }

        /// <summary>
        /// Обработка нажатия по форме
        /// </summary>
        /// <param name="sender">Отправитель</param>
        /// <param name="e">Event</param>
        private void HelloForm_MouseClick(object sender, MouseEventArgs e)
        {
            timer1.Stop();
            new TenantsForm().Show();
            this.Hide();
        }

        /// <summary>
        /// Обработка нажатия любой клавиши
        /// </summary>
        /// <param name="sender">Отправитель</param>
        /// <param name="e">Event</param>
        private void HelloForm_KeyDown(object sender, KeyEventArgs e)
        {
            timer1.Stop();
            new TenantsForm().Show();
            this.Hide();
        }
    }
}
